using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Model;
// using Game.View;


namespace Game.Controller
{
    public class SimpleBullet : BaseBullet
    {
        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);

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