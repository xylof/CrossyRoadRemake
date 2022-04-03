using SDA.Core;
using SDA.Data;
using SDA.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SDA.Generation
{
    public class LaneGenerator : MonoBehaviour
    {
        [SerializeField] private Lane lanePrefab;
        [SerializeField] private Transform lanesParent;
        [SerializeField] private Transform startingPos;
        [SerializeField] private float distance = 1.5f;
        private int counter;

        private CarPool<Car> carPool;

        public void GenerateLevel(CarPool<Car> carPool, int lanesCount)
        {
            this.carPool = carPool;

            for (int i = 0; i < lanesCount; i++)
            {
                var randomCar = Random.Range(0, 8);
                var spawnPointIndex = Random.Range(0, 2);

                GenerateLane(carPool, (CarType)randomCar, spawnPointIndex);
            }
        }

        private void OnLanedespawn()
        {
            var randomCar = Random.Range(0, 8);
            var spawnPointIndex = Random.Range(0, 2);

            GenerateLane(carPool, (CarType)randomCar, spawnPointIndex);
        }

        public void GenerateLane(CarPool<Car> carPool, CarType carType, int spawnPointIndex)
        {
            Lane lane = Instantiate(lanePrefab, lanesParent);

            lane.transform.position = startingPos.position + Vector3.right * distance * counter++;
            lane.transform.rotation = startingPos.rotation;
            lane.SetColor(counter);
            lane.InitializeLane(carPool, carType, spawnPointIndex);
            lane.OnDespawnAddListener(OnLanedespawn);
        }
    } 
}
