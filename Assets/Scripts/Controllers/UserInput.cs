using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Game.Model;
// using Game.View;


namespace Game.Controller
{
    public class UserInput : MonoBehaviour
    {
        public Vector2Event InputDirection = new Vector2Event();
        public UnityEvent Attack1 = new UnityEvent();
        public UnityEvent Attack2 = new UnityEvent();

        private void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            if (horizontal != 0f || vertical != 0f)
            {
                InputDirection?.Invoke(new Vector2(horizontal, vertical));
            }

            if (Input.GetMouseButton(0))
            {
                Attack1?.Invoke();
            }

            if (Input.GetMouseButton(1))
            {
                Attack2?.Invoke();
            }


        }
    }
}
