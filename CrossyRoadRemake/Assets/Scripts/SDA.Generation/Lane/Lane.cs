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

        public void InitialzieLane()
        {
            StartCoroutine(GenerateCar(3f));
        }

        private IEnumerator GenerateCar(float timeBetweenSpawns)
        {
            while (true)
            {
                carGenerator.SpawnCar();
                yield return new WaitForSeconds(timeBetweenSpawns);
            }
        }
    } 
}
