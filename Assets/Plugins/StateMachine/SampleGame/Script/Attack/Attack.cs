using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineX.SampleGame
{
    public class Attack : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D    _Rigid;
        [SerializeField]
        private Collider2D     _Collider;
        [SerializeField]
        private SpriteRenderer _Sprite;
        [SerializeField]
        private TagColor       _TagColor;
        [SerializeField]
        private float          _Speed;
        [SerializeField]
        private float          _Damage;

        private Attacking _Belong;

        private Action<AttackInfo> _TakeDamage = (info) => { };

        public void Set(Attacking belong) 
        {
            _Belong = belong;
        }

        public void Set(Transform parent)
        {
            //transform.SetParent(parent);
            
            tag = parent.tag;

            _Sprite.color = _TagColor[tag];
        }

        public void Set(float speed, float damage) 
        {
            _Speed  = speed;
            _Damage = damage;
        }

        public void Set(Vector3 position, Quaternion rotation)
        {
            transform.SetPositionAndRotation(position, rotation);
        }

        public void TakeDamage(Action<AttackInfo> takeDamage) 
        {
            _TakeDamage = takeDamage;
        }

        public void Update() 
        {
            var velocity = Quaternion.Euler(0f, 0f, _Rigid.rotation) * Vector2.up * _Speed;
            
            _Rigid.velocity = velocity;
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            var contact = collision.tag;

            if (contact == tag) { return; }

            var character = collision.GetComponent<Character>();
                
            if (character && !character.IsHurt) 
            {
                character.Hurt();

                _TakeDamage.Invoke(new AttackInfo(character.tag, character.Id, _Damage));
            }

            _Belong.Recycle(this);
        }

        [Serializable]
        private struct TagColor 
        {
            [SerializeField]
            private Color _Player;
            [SerializeField]
            private Color _Enemy;

            public Color Player => _Player;
            public Color Enemy  => _Enemy;

            public Color this[string tag] 
            {
                get 
                {
                    if (tag == "Player") { return Player; }
                    if (tag == "Enemy" ) { return Enemy; }

                    return Color.white;
                }
            }
        }
    }

    public struct AttackInfo 
    {
        public AttackInfo(string tag, int id, float damage) 
        {
            Tag    = tag;
            Id     = id;
            Damage = damage;
        }

        public string Tag    { get; }
        public int    Id     { get; }
        public float  Damage { get; }
    }
}
