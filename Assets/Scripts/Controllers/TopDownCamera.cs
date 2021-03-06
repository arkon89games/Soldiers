using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controller
{
    public class TopDownCamera : MonoBehaviour
    {
        private Vector3 _offSet;
        [SerializeField] private Transform _target;
        [SerializeField] private float _followSpeed = 1f;
        void Start()
        {
            _offSet = transform.position - _target.position;
        }

        // Update is called once per frame
        void LateUpdate()
        {
            Vector3 newPosition = _target.position + _offSet;
            transform.position = Vector3.Lerp(transform.position, newPosition, _followSpeed);
        }
    }
}
