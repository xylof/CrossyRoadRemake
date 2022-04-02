using SDA.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SDA.Data
{
    [CreateAssetMenu(menuName = "Crossy/Car/New Car")]
    public class CarData : ScriptableObject
    {
        [SerializeField] private Car prefab;
        [SerializeField] private float baseSpeed;

        public Car Prefab => prefab;
        public float BaseSpeed => baseSpeed;
    } 
}
