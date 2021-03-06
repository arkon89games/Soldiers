using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Game.View;
using Game.Model;

namespace Game.Controller
{
    public class SimpleWeapon : BaseWeapon
    {
        private SimpleBullet _lastBullet;


        public void Fire()
        {
            if (_attackTimer > 0f)
            {
                return;
            }

            Vector3 direction = transform.forward;
            // direction = transform.TransformPoint(direction);
            _attackTimer = _attackDelay;
            _lastBullet = BulletPool.Instance.GetSimpleBulletOrReturnNullIfPoolEmpty();

            // direction = Vector3.ProjectOnPlane(direction - transform.position, Vector3.up);
            _lastBullet.transform.position = _spawnTransform.position;
            _lastBullet.Shot(direction);
        }
    }
}