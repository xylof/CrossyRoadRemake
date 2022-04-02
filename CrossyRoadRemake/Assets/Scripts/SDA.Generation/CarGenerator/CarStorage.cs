using SDA.Core;
using SDA.Data;
using SDA.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SDA.Generation
{
    public class CarStorage : MonoBehaviour
    {
        [SerializeField] private Transform storageParent;

        [SerializeField] private Car ambulancePrefab;
        [SerializeField] private Car deliveryPrefab;
        [SerializeField] private Car firetruckPrefab;
        [SerializeField] private Car hatchbackPrefab;
        [SerializeField] private Car policePrefab;
        [SerializeField] private Car sedanPrefab;
        [SerializeField] private Car taxiPrefab;
        [SerializeField] private Car tractorPrefab;

        private CarPool<Car> carsPool;

        public CarPool<Car> CarsPool => carsPool;

        public void InitializeStorage()
        {
            var sizes = new Dictionary<CarType, int>();
            sizes.Add(CarType.Ambulance, 15);
            sizes.Add(CarType.Delivery, 15);
            sizes.Add(CarType.Firetruck, 15);
            sizes.Add(CarType.HatchbackSports, 15);
            sizes.Add(CarType.Police, 15);
            sizes.Add(CarType.Sedan, 15);
            sizes.Add(CarType.Taxi, 15);
            sizes.Add(CarType.Tractor, 15);

            carsPool = new CarPool<Car>(sizes);
            InitializePool(CarType.Ambulance, ambulancePrefab);
            InitializePool(CarType.Delivery, deliveryPrefab);
            InitializePool(CarType.Firetruck, firetruckPrefab);
            InitializePool(CarType.HatchbackSports, hatchbackPrefab);
            InitializePool(CarType.Police, policePrefab);
            InitializePool(CarType.Sedan, sedanPrefab);
            InitializePool(CarType.Taxi, taxiPrefab);
            InitializePool(CarType.Tractor, tractorPrefab);
        }

        private void InitializePool(CarType type, Car prefab)
        {
            for (int i = 0; i < carsPool.GetSize(type); i++)
            {
                var obj = Instantiate(prefab);
                carsPool.ReturnToPool(type, obj, storageParent);
            }
        }
    } 
}
