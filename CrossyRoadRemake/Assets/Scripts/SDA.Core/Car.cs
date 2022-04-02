using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDA.Utils;
using SDA.Data;

namespace SDA.Core
{
    public class Car : MonoBehaviour, IPoolable
    {
        [SerializeField] private CarData carData;
        [SerializeField] private Rigidbody carRigidbody;

        public void Move(Vector3 direction, float speed)
        {
            carRigidbody.AddForce(direction * Time.fixedDeltaTime * speed, ForceMode.Impulse);
        }

        public float GetSpeed()
        {
            return carData.BaseSpeed;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Wall"))
                Destroy(gameObject);
        }

        public void PrepareForActivate()
        {
            gameObject.SetActive(true);
        }

        public void PrepareForDeactivate(Transform parent)
        {
            gameObject.SetActive(false);
            transform.SetParent(parent);
        }
    } 
}
