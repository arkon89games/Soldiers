using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Game.View;
// using Game.Model;

namespace Game.Controller
{
    [RequireComponent(typeof(SphereCollider))]
    public class BulletSensor : MonoBehaviour
    {
        [SerializeField] private BaseBullet _bullet;

        private void OnTriggerEnter(Collider other)
        {

            SoldierHP targetHp = other.gameObject.GetComponent<SoldierHP>();
            if (targetHp != null && targetHp != _bullet.Shooter)
            {
                _bullet.Shot((other.transform.position - transform.position) * 3f);
            }

        }
    }
}