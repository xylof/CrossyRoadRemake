using Sda.Data;
using SDA.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SDA.Generation
{
    public class CarGenerator : MonoBehaviour
    {
        [SerializeField]
        private Transform spawnPoint1;

        [SerializeField]
        private Transform spawnPoint2;

        [SerializeField]
        private CarData[] cars;

        public void SpawnCar()
        {
            int randomIndex = Random.Range(0, cars.Length);
            CarData carData = cars[randomIndex];

            Car instantiatedCar = Instantiate(carData.Prefab, spawnPoint1.parent, true);
            instantiatedCar.transform.localPosition = spawnPoint1.localPosition;
            instantiatedCar.transform.localRotation = spawnPoint1.localRotation;

            instantiatedCar.Move();
        }
    } 
}
