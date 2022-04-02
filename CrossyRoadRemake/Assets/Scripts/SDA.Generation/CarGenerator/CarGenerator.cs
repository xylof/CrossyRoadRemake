using SDA.Core;
using SDA.Data;
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
        [SerializeField] private CarData[] cars;

        public void SpawnCar(Transform parent)
        {
            int randomIndex = Random.Range(0, cars.Length);
            int randomPoint = Random.Range(0, spawnPoints.Length);
            CarData carData = cars[randomIndex];

            Car instantiatedCar = Instantiate(carData.Prefab, parent, true);

            instantiatedCar.transform.position = spawnPoints[randomPoint].spawnPositionTransform.position;
            instantiatedCar.transform.rotation = spawnPoints[randomPoint].spawnPositionTransform.rotation;

            instantiatedCar.Move(spawnPoints[randomPoint].GetDirection(), carData.BaseSpeed);
        }
    } 
}
