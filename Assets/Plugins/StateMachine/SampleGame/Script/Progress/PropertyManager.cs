using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineX.SampleGame
{
    public class PropertyManager : MonoBehaviour
    {
        [SerializeField]
        private Property _Player;
        [SerializeField]
        private List<Property> _Enemies = new();

        private int _EnemyId = 0;

        public Property GetPlayer() 
        {
            _Player = _Player ?? new Property(0);

            return _Player;
        }

        public Property GetEnemy() 
        {
            var property = new Property(_EnemyId++);

            _Enemies.Add(property);

            return property;
        }

        public void SetPlayer(float delta) 
        {
            _Player.Health -= delta;
        }

        public void SetEnemy(int id, float delta)
        {
            var enemy = _Enemies.FirstOrDefault(p => p.Id == id);
            
            enemy.Health -= delta;
        }

        public void RemoveDeadEnemy() 
        {
            _Enemies.RemoveAll(p => p.Health <= 0);
        }

        public void Initialize()
        {
            _Player = default;

            _Enemies.Clear();
        }
    }

    [Serializable]
    public class Property 
    {
        public Property(int id)
        {
            _Id = id;
        }

        public Property(int id, int health) 
        {
            _Id     = id;
            _Health = health;
        }

        [SerializeField]
        private int   _Id;
        [SerializeField]
        private float _Health;

        public int Id => _Id;

        public float Health 
        {
            get => _Health;
            
            set => _Health = value;
        }
    }
}
