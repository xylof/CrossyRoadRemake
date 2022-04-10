using SDA.Core;
using SDA.Data;
using SDA.Utils;
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
        [SerializeField] private Car trainPrefab;

        private CarPool<Car> carsPool;

        public CarPool<Car> CarsPool => carsPool;

        public void InitializeStorage()
        {
            var sizes = new Dictionary<CarType, int>();
            sizes.Add(CarType.Ambulance, 50);
            sizes.Add(CarType.Delivery, 50);
            sizes.Add(CarType.Firetruck, 50);
            sizes.Add(CarType.HatchbackSports, 50);
            sizes.Add(CarType.Police, 50);
            sizes.Add(CarType.Sedan, 50);
            sizes.Add(CarType.Taxi, 50);
            sizes.Add(CarType.Tractor, 50);
            sizes.Add(CarType.Train, 50);

            carsPool = new CarPool<Car>(sizes, storageParent);
            InitializePool(CarType.Ambulance, ambulancePrefab);
            InitializePool(CarType.Delivery, deliveryPrefab);
            InitializePool(CarType.Firetruck, firetruckPrefab);
            InitializePool(CarType.HatchbackSports, hatchbackPrefab);
            InitializePool(CarType.Police, policePrefab);
            InitializePool(CarType.Sedan, sedanPrefab);
            InitializePool(CarType.Taxi, taxiPrefab);
            InitializePool(CarType.Tractor, tractorPrefab);
            InitializePool(CarType.Train, trainPrefab);
        }

        private void InitializePool(CarType type, Car prefab)
        {
            for (int i = 0; i < carsPool.GetSize(type); i++)
            {
                var obj = Instantiate(prefab);
                carsPool.ReturnToPool(type, obj);
            }
        }
    } 
}
