using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SDA.Core
{
    public class Car : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody carRigidbody;

        public void Move(Vector3 direction, float speed)
        {
            carRigidbody.AddForce(direction * Time.fixedDeltaTime * speed, ForceMode.Impulse);
        }
    } 
}
