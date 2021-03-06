using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Game.View;
// using Game.Model;

namespace Game.Controller
{
    public class HandsIK : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _leftHandPlace;
        [SerializeField] private Transform _rightHandPlace;

        private Transform _leftHand, _rightHand;

        private void Start()
        {
            _leftHand = _animator.GetBoneTransform(HumanBodyBones.LeftHand);
            _rightHand = _animator.GetBoneTransform(HumanBodyBones.RightHand);
        }

        void OnAnimatorIK()
        {

            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
            _animator.SetIKPosition(AvatarIKGoal.RightHand, _rightHandPlace.position);

            _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);
            _animator.SetIKRotation(AvatarIKGoal.RightHand, _rightHandPlace.rotation);


            _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
            _animator.SetIKPosition(AvatarIKGoal.LeftHand, _leftHandPlace.position);

            _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);
            _animator.SetIKRotation(AvatarIKGoal.LeftHand, _leftHandPlace.rotation);
        }



    }
}