using UnityEngine;

namespace SDA.Utils
{
    public interface IPoolable
    {
        void PrepareForActivate();
        void PrepareForDeactivate(Transform parent);
    } 
}
