using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controller
{
    [RequireComponent(typeof(Rigidbody))]
    public class MoveDirection : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 0.1f;
        [SerializeField] private float _moveSpeed = 0.1f;
        private Animator _animator;
        private Rigidbody _rigidBody;


        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
        }

        public void SetDirection(Vector2 direction)
        {
            Debug.Log($"{direction.x} : {direction.y}");
            Rotate(direction);
            Move(direction);
        }

        private void Rotate(Vector2 direction)
        {
            Vector3 direct = Vector3.zero;
            direct.x = direction.x;
            direct.z = direction.y;
            Vector3 look = Vector3.RotateTowards(transform.forward, direct, _rotationSpeed, 0f);

            transform.rotation = Quaternion.LookRotation(look);
        }

        private void Move(Vector2 direction)
        {
            Vector3 dir = new Vector3(direction.x, 0f, direction.y);
            // transform.Translate(dir * _moveSpeed * Time.deltaTime, Space.World);
            _rigidBody.AddForce(dir * _moveSpeed * Time.deltaTime);
        }

        private void Update()
        {
            _animator.SetFloat("velocity", _rigidBody.velocity.magnitude);
        }



    }
}
