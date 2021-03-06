using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Game.View;
// using Game.Model;

namespace Game.Controller
{
    public class Graveyard : MonoBehaviour
    {
        public static Graveyard Instance;

        private void Awake()
        {
            Instance = this;
        }

        public void AddDead(GameObject dead)
        {
            StartCoroutine(Revive(dead));
        }

        public IEnumerator Revive(GameObject dead)
        {
            dead.SetActive(false);
            yield return new WaitForSecondsRealtime(5f);
            dead.SetActive(true);
        }

    }
}