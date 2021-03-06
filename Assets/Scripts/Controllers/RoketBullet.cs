using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Game.View;
// using Game.Model;

namespace Game.Controller
{
    [RequireComponent(typeof(Rigidbody))]
    public class RoketBullet : BaseBullet
    {
        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);

            SoldierHP targetHp = other.gameObject.GetComponent<SoldierHP>();
            if (targetHp == Shooter)
            {
                return;
            }
            Die();
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer > _lifeTime)
            {
                Die();
            }

        }
        private void Die()
        {
            _targetPosition = Vector3.zero;
            gameObject.SetActive(false);
            BulletPool.Instance.BackToPool(this);
        }
    }
}