using SDA.Core;
using SDA.Data;
using SDA.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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

        public void InitializeGenerator(CarPool<Car> pool, CarType type, int spawnIndex)
        {
            this.pool = pool;
            typeToSpawn = type;
            spawnPointIndex = spawnIndex;
        }

        public void SpawnCar(Transform parent)
        {
            Car obj = pool.GetFromPool(typeToSpawn);
            obj.transform.SetParent(parent);
            obj.transform.position = spawnPoints[spawnPointIndex].spawnPositionTransform.position;
            obj.transform.rotation = spawnPoints[spawnPointIndex].spawnPositionTransform.rotation;
            obj.Move(spawnPoints[spawnPointIndex].GetDirection(), obj.GetSpeed());
        }
    } 
}
