using System;
using System.Collections;
using System.Collections.Generic;

namespace StateMachineX
{
    public static partial class StateMachine
    {
        /// <summary>
        /// �ǦC���A���A�i�z�L���A��Identity�ƧǨȩ̀Ƕi��A����k�|�H�N�ؼЪ��A�����ഫ�j����ǦC�ഫ�A
        /// �Ȥ����q�D���A���C
        /// </summary>
        /// <returns></returns>
        public static ISequenceStateMachine Sequence(this IStateMachine self)
        {
            return new SequenceStateMachine(self);
        }

        /// <summary>
        /// �N�ǦC���A���ƧǡC
        /// </summary>
        /// <param name="self"></param>
        /// <param name="identities">�ƦC�᪺���AIdentity</param>
        /// <returns></returns>
        public static ISequenceStateMachine OrderBy(this ISequenceStateMachine self, params object[] identities)
        {
            self.OrderBy(new SequenceOrder(identities));

            return self;
        }

        /// <summary>
        /// �N�ǦC���A���ƧǡC
        /// </summary>
        /// <param name="self"></param>
        /// <param name="identities">�ƦC�᪺���AIdentity</param>
        /// <returns></returns>
        public static ISequenceStateMachine OrderBy(this ISequenceStateMachine self, IEnumerable<object> identities)
        {
            self.OrderBy(new SequenceOrder(identities));

            return self;
        }

        public static ISequenceStateMachine WithId(this ISequenceStateMachine self, object identity) 
        {
            self.SetIdentity(identity);
            
            return self;
        }
    }
}
