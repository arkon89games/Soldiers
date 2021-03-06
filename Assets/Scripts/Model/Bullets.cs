using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Model
{
    [CreateAssetMenu(fileName = "Bullets", menuName = "Game/Bullets", order = 0)]
    public class Bullets : ScriptableObject
    {
        public Controller.SimpleBullet SimpleBulletPrefab;
        public Controller.RoketBullet RoketBulletPrefab;
    }
}