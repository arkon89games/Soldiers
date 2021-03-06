using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Game.View;
// using Game.Model;

namespace Game.Controller
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class BaseBullet : MonoBehaviour, IBullet
    {
        [SerializeField] protected float _moveSpeed;
        [SerializeField] protected float _lifeTime = 10;
        protected float _timer;
        protected Vector3 _targetPosition = Vector3.zero;
        protected Rigidbody _rigidbody;
        public SoldierHP Shooter;

        private void OnEnable()
        {
            if (_rigidbody == null)
            {
                _rigidbody = GetComponent<Rigidbody>();
            }
            _timer = 0f;
        }
        public virtual void Shot(Vector3 direction)
        {
            gameObject.SetActive(true);
            _rigidbody.velocity = direction * _moveSpeed;
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            SoldierHP targetHp = other.gameObject.GetComponent<SoldierHP>();
            if (targetHp != null && targetHp != Shooter)
            {
                targetHp.Hit();
            }
        }
    }
}