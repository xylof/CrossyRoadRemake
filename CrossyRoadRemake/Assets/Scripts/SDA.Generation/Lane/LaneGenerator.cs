using SDA.Core;
using SDA.Data;
using SDA.Utils;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SDA.Generation
{
    [Serializable]
    public class Chunk
    {
        public Vector2 ranges;
        public List<LanesTemplate> templates;

        public bool IsBetween(int count)
        {
            return ranges.x <= count && count <= ranges.y;
        }
    }

    public class LaneGenerator : MonoBehaviour
    {
        //[SerializeField] private Lane lanePrefab;

        [SerializeField] private List<Chunk> chunks;

        [SerializeField] private Transform lanesParent;
        [SerializeField] private Transform startingPos;
        [SerializeField] private float distance = 1.5f;
        private int counter;

        private CarPool<Car> carPool;

        private LanesTemplate currentTemplate;
        private int templateIterator = 0;

        public void GenerateLevel(CarPool<Car> carPool, int lanesCount)
        {
            this.carPool = carPool;
            var chunk = GetChunk();
            currentTemplate = GetTemplate(chunk);

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

        private Chunk GetChunk()
        {
            for (int i = 0; i < chunks.Count; i++)
            {
                var chunk = chunks[i];
                if (chunk.IsBetween(counter))
                    return chunk;
            }
            return chunks[chunks.Count - 1];
        }

        private LanesTemplate GetTemplate(Chunk chunk)
        {
            var randomTemplate = Random.Range(0, chunk.templates.Count);
            return chunk.templates[randomTemplate];
        }

        public void GenerateLane(CarPool<Car> carPool, CarType carType, int spawnPointIndex)
        {
            if (templateIterator == currentTemplate.lanes.Length)
            {
                var chunk = GetChunk();
                currentTemplate = GetTemplate(chunk);
                templateIterator = 0;
            }

            var lanePrefab = currentTemplate.lanes[templateIterator];
            templateIterator++;

            Lane lane = Instantiate(lanePrefab, lanesParent);
            lane.transform.position = startingPos.position + Vector3.right * distance * counter++;
            lane.transform.rotation = startingPos.rotation;
            lane.SetColor(counter);
            lane.InitializeLane(carPool, carType, spawnPointIndex);
            lane.OnDespawnAddListener(OnLanedespawn);
        }
    } 
}
