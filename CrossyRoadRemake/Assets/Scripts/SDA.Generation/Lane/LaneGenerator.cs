using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SDA.Generation
{
    public class LaneGenerator : MonoBehaviour
    {
        [SerializeField]
        private Lane lanePrefab;

        [SerializeField]
        private GameObject lanesParent;

        [SerializeField]
        private Transform startingPos;

        [SerializeField]
        private float distance = 1.5f;

        private int counter;

        public void GenerateLevel(int lanesCount)
        {
            for (int i = 0; i < lanesCount; i++)
            {
                GenerateLane();
            }
        }

        public void GenerateLane()
        {
            Lane lane = Instantiate(lanePrefab, lanesParent.transform, true);

            lane.transform.position = startingPos.position + Vector3.right * distance * counter++;
            lane.transform.rotation = startingPos.rotation;
            lane.SetColor(counter);

            lane.InitialzieLane();
        }
    } 
}
