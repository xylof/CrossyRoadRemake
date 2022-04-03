using SDA.Core;
using SDA.Data;
using SDA.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SDA.Generation
{
    public class Lane : MonoBehaviour
    {
        [SerializeField]
        private CarGenerator carGenerator;

        [SerializeField] private MeshRenderer meshRenderer;

        [SerializeField] private Color brightColor;
        [SerializeField] private Color darkColor;

        private UnityAction onDespawn;

        public void SetColor(int count)
        {
            if (count % 2 == 0)
            {
                meshRenderer.material.color = darkColor;
            }
            else
            {
                meshRenderer.material.color = brightColor;
            }
        }

        public void InitializeLane(CarPool<Car> carPool, CarType carType, int spawnPointIndex)
        {
            carGenerator.InitializeGenerator(carPool, carType, spawnPointIndex);
            StartCoroutine(GenerateCar(5f));
        }

        private IEnumerator GenerateCar(float timeBetweenSpawns)
        {
            while (true)
            {
                carGenerator.SpawnCar(transform.parent);
                yield return new WaitForSeconds(timeBetweenSpawns);
            }
        }

        public void OnDespawnAddListener(UnityAction callback)
        {
            onDespawn = callback;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Wall"))
            {
                StopAllCoroutines();
                carGenerator.DespawnCars();
                onDespawn.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
