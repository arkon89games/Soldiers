using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Game.View;
using Game.Model;

namespace Game.Controller
{
    public class BulletPool : MonoBehaviour
    {
        public static BulletPool Instance;
        [SerializeField] private Bullets _bulletsSO;
        [SerializeField] int _poolCount;

        private Stack<SimpleBullet> _simpleBullets = new Stack<SimpleBullet>();
        private Stack<RoketBullet> _roketBullets = new Stack<RoketBullet>();


        private void Awake()
        {
            Initialise();
        }
        public void Initialise()
        {
            Instance = this;
            for (int i = 0; i < _poolCount; i++)
            {
                SimpleBullet bullet = Instantiate<SimpleBullet>(_bulletsSO.SimpleBulletPrefab);
                bullet.gameObject.SetActive(false);
                _simpleBullets.Push(bullet);

            }
            for (int i = 0; i < _poolCount; i++)
            {
                RoketBullet bullet = Instantiate<RoketBullet>(_bulletsSO.RoketBulletPrefab);
                bullet.gameObject.SetActive(false);
                _roketBullets.Push(bullet);

            }
        }

        public void BackToPool(SimpleBullet bullet)
        {
            _simpleBullets.Push(bullet);
        }
        public void BackToPool(RoketBullet bullet)
        {
            _roketBullets.Push(bullet);
        }

        public SimpleBullet GetSimpleBulletOrReturnNullIfPoolEmpty()
        {
            if (_simpleBullets.Count > 0)
            {
                return (SimpleBullet)_simpleBullets.Pop();
            }
            else
            {
                return null;
            }
        }

        public RoketBullet GetRoketBulletOrReturnNullIfPoolEmpty()
        {
            if (_roketBullets.Count > 0)
            {
                return (RoketBullet)_roketBullets.Pop();
            }
            else
            {
                return null;
            }
        }
    }
}