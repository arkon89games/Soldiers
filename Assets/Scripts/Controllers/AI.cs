using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Game.View;
// using Game.Model;

namespace Game.Controller
{
    public class AI : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private MoveDirection _motor;
        [SerializeField] private SimpleWeapon _simpleWeapon;
        [SerializeField] private RoketWeapon _roketWeapon;



        private void RotateToTarget(Transform target)
        {
            float angle = Vector3.Angle(transform.forward, target.position - transform.position);
            if (Mathf.Abs(angle) > 3f)
            {
                Vector3 directionV3 = target.position - transform.position;//transform.InverseTransformDirection(target.position - transform.position);
                Vector2 directionV2 = new Vector2(directionV3.x, directionV3.z);
                directionV2.Normalize();
                _motor.SetDirection(directionV2);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            Transform target = other.transform;
            float angle = Vector3.Angle(transform.forward, target.position - transform.position);

            if (target != null && target == _target)
            {
                if (Mathf.Abs(angle) > 3f)
                {
                    Debug.Log("angle = " + angle);
                    RotateToTarget(_target);
                }
                else
                {
                    int index = Random.Range(0, 100);
                    if (index == 0)
                    {
                        _simpleWeapon.Fire();
                    }
                    else if (index == 1)
                    {
                        _roketWeapon.Fire();
                    }
                }
            }
        }
    }
}