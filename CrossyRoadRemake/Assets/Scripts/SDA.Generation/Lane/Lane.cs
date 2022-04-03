using SDA.Core;
using SDA.Data;
using SDA.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SDA.Generation
{
    public class Lane : MonoBehaviour
    {
        [SerializeField]
        private CarGenerator carGenerator;

        [SerializeField] private MeshRenderer meshRenderer;

        [SerializeField] private Color brightColor;
        [SerializeField] private Color darkColor;

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
    } 
}
