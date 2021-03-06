using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Controller
{

    public abstract class BaseWeapon : MonoBehaviour
    {
        [SerializeField] protected float _fireDistance = 10f;
        [SerializeField] protected float _attackDelay = 1f;
        [SerializeField] protected Transform _spawnTransform;
        protected float _attackTimer = 0f;


        private void Update()
        {
            if (_attackTimer >= 0f)
            {
                _attackTimer -= Time.deltaTime;
            }
        }
    }
}