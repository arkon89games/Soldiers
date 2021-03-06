using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Game.View;
// using Game.Model;

namespace Game.Controller
{
    public class SoldierHP : MonoBehaviour
    {
        [SerializeField] private GameObject _soldierRoot;
        public void Hit()
        {
            Graveyard.Instance.AddDead(_soldierRoot);
        }
    }
}