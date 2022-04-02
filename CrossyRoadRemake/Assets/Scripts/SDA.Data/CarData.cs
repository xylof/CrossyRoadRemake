using SDA.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SDA.Data
{
    [CreateAssetMenu(menuName = "Crossy/Car/New Car")]
    public class CarData : ScriptableObject
    {
        [SerializeField] private float baseSpeed;
        public float BaseSpeed => baseSpeed;
    } 
}
