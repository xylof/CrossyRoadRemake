using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDA.Utils;
using SDA.Data;
using UnityEngine.Events;

namespace SDA.Core
{
    public class Car : MonoBehaviour, IPoolable
    {
        [SerializeField] private CarData carData;
        [SerializeField] private Rigidbody carRigidbody;

        private UnityAction<Car> onWallHit;

        public void Move(Vector3 direction, float speed)
        {
            carRigidbody.AddForce(direction * Time.fixedDeltaTime * speed, ForceMode.Impulse);
        }

        public float GetSpeed()
        {
            return carData.BaseSpeed;
        }

        public void OnWallHitAddListener(UnityAction<Car> onWallHit)
        {
            this.onWallHit = onWallHit;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Wall"))
                onWallHit.Invoke(this);
        }

        public void PrepareForActivate()
        {
            carRigidbody.velocity = Vector3.zero;
            gameObject.SetActive(true);
        }

        public void PrepareForDeactivate(Transform parent)
        {
            gameObject.SetActive(false);
            transform.SetParent(parent);
        }
    } 
}
