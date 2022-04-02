using SDA.Data;
using System.Collections.Generic;
using UnityEngine;

namespace SDA.Utils
{
    public class CarPool<TPoolable> where TPoolable : IPoolable
    {
        private Dictionary<CarType, Stack<TPoolable>> pooledObjects = new Dictionary<CarType, Stack<TPoolable>>();
        private Dictionary<CarType, int> sizes = new Dictionary<CarType, int>();

        public int GetSize(CarType type)
        {
            return sizes[type];
        }

        public CarPool(Dictionary<CarType, List<TPoolable>> objectsToPool)
        {
            foreach (KeyValuePair<CarType, List<TPoolable>> kvp in objectsToPool)
            {
                sizes.Add(kvp.Key, kvp.Value.Count);
                var objectsStack = new Stack<TPoolable>();

                foreach (TPoolable car in kvp.Value)
                {
                    objectsStack.Push(car);
                }
                pooledObjects.Add(kvp.Key, objectsStack);
            }
        }

        public CarPool(Dictionary<CarType, int> sizes)
        {
            foreach (KeyValuePair<CarType, int> kvp in sizes)
            {
                this.sizes.Add(kvp.Key, kvp.Value);
                var objectsStack = new Stack<TPoolable>();
                pooledObjects.Add(kvp.Key, objectsStack);
            }
        }

        public TPoolable GetFromPool(CarType type)
        {
            if (pooledObjects[type].Count > 0)
            {
                TPoolable obj = pooledObjects[type].Pop();
                obj.PrepareForActivate();
                return obj;
            }
            return default;
        }

        public bool TryGetFromPool(CarType type, out TPoolable item)
        {
            item = GetFromPool(type);

            if (item != null)
                return true;
            return false;
        }

        public void ReturnToPool(CarType type, TPoolable car, Transform parent)
        {
            if (pooledObjects[type].Count <= sizes[type])
            {
                car.PrepareForDeactivate(parent);
                pooledObjects[type].Push(car);
            }
        }

        public bool TryReturnToPool(CarType type, TPoolable car, Transform parent)
        {
            if (pooledObjects[type].Count <= sizes[type])
            {
                car.PrepareForDeactivate(parent);
                pooledObjects[type].Push(car);
                return true;
            }
            return false;
        }
    }
}
