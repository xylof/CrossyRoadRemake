using SDA.Core;
using SDA.Data;
using SDA.Utils;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SDA.Generation
{
    public enum Direction
    {
        Forward,
        Backward
    }

    [Serializable]
    public class SpawnPoint
    {
        public Transform spawnPositionTransform;
        public Direction direction;

        public Vector3 GetDirection()
        {
            if (direction == Direction.Forward)
                return Vector3.forward;
            return Vector3.back;
        }
    }

    public class CarGenerator : MonoBehaviour
    {
        [SerializeField] private SpawnPoint[] spawnPoints;

        private CarPool<Car> pool;
        private CarType typeToSpawn;
        private int spawnPointIndex;

        private List<Car> spawnedCars = new List<Car>();

        [SerializeField]
        private bool isEnalbed = true;

        public void InitializeGenerator(CarPool<Car> pool, CarType type, int spawnIndex)
        {
            this.pool = pool;
            typeToSpawn = type;
            spawnPointIndex = spawnIndex;
        }

        private void ReturnToPool(Car car)
        {
            spawnedCars.Remove(car);
            pool.ReturnToPool(typeToSpawn, car);
        }

        public void SpawnCar(Transform parent)
        {
            if (!isEnalbed)
                return;

            Car car = pool.GetFromPool(typeToSpawn);
            car.transform.SetParent(parent);
            car.transform.position = spawnPoints[spawnPointIndex].spawnPositionTransform.position;
            car.transform.rotation = spawnPoints[spawnPointIndex].spawnPositionTransform.rotation;
            car.OnWallHitAddListener(ReturnToPool);
            car.Move(spawnPoints[spawnPointIndex].GetDirection(), car.GetSpeed());
            spawnedCars.Add(car);
        }

        public void DespawnCars()
        {
            for (int i = 0; i < spawnedCars.Count; i++)
            {
                pool.ReturnToPool(typeToSpawn, spawnedCars[i]);
            }
            spawnedCars.Clear();
        }
    } 
}
