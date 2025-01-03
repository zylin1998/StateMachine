using System;
using System.Linq;
using System.Collections.Generic;

namespace StateMachine.Internal
{
    internal class MachineCollection
    {
        private object _CollectionLock = new object();

        private List<IMachineTicker>  _Tickers = new();
        private Queue<IMachineTicker> _Await   = new();

        public int ThreadCount      => _Tickers.Count;
        public int ValidThreadCount => _Tickers.Count(t => t.IsValid);

        public IDisposable Register(IMachineTicker ticker) 
        {
            lock (_CollectionLock) 
            {
                _Await.Enqueue(ticker);
            }

            return new Disposable(this, ticker);
        }

        public void Tick() 
        {
            _Tickers = CheckValid().ToList();
        }

        private IEnumerable<IMachineTicker> CheckValid() 
        {
            foreach (var ticker in _Tickers) 
            {
                if (ticker.IsValid) 
                {
                    ticker.Tick();

                    yield return ticker;
                }
            }

            for (; _Await.Any();) 
            {
                var ticker = _Await.Dequeue();

                if (ticker.IsValid) 
                {
                    ticker.Tick();

                    yield return ticker;
                }
            }
        }

        private class Disposable : IDisposable 
        {
            MachineCollection _Source;
            IMachineTicker    _Ticker;

            private bool _IsDisposed = false;

            public Disposable(MachineCollection source, IMachineTicker ticker)
            {
                _Source = source;
                _Ticker = ticker;
            }

            public void Dispose() 
            {
                lock (_Source._CollectionLock) 
                {
                    if (_IsDisposed) { return; }

                    _IsDisposed = true;

                    _Ticker.Dispose();

                    if (_Ticker.Machine is IDisposable disposable) 
                    {
                        disposable.Dispose();
                    }
                }
            }
        }
    }
}
