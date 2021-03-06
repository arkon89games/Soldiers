using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Game.View;
// using Game.Model;

namespace Game.Controller
{
    public class RoketWeapon : BaseWeapon
    {
        [SerializeField] private float angleInDegreees = -45f;
        [SerializeField] private SoldierHP _shooter;
        private float g = Physics.gravity.y;

        private RoketBullet _lastBullet;
        public void Fire()
        {
            if (_attackTimer > 0f)
            {
                return;
            }


            Vector3 targetPosition = (Vector3.forward * _fireDistance);
            targetPosition = transform.TransformPoint(targetPosition);

            _attackTimer = _attackDelay;
            _lastBullet = BulletPool.Instance.GetRoketBulletOrReturnNullIfPoolEmpty();

            float distance = Vector3.Distance(transform.position, targetPosition);
            float y = targetPosition.y;
            float angleInRadians = angleInDegreees * Mathf.PI / 180f;
            float v2 = (g * distance * distance) / (2 * (y - Mathf.Tan(angleInRadians) * distance) * Mathf.Pow(Mathf.Cos(angleInRadians), 2));
            float v = Mathf.Sqrt(Mathf.Abs(v2));

            float sideRandom = Random.Range(-0.5f, 0.5f);
            Vector3 sideSpread = transform.right * sideRandom;
            //Physics.IgnoreCollision()
            _lastBullet.Shooter = _shooter;
            _lastBullet.transform.position = _spawnTransform.position;
            _lastBullet.Shot((_spawnTransform.forward * v) + sideSpread);
        }
    }
}