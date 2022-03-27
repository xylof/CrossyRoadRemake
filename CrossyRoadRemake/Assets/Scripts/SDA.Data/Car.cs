using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sda.Data
{
    public class Car : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody carRigidbody;

        public void Move()
        {
            carRigidbody.AddForce(transform.forward * Time.fixedDeltaTime * 500f, ForceMode.Impulse);
        }
    } 
}
