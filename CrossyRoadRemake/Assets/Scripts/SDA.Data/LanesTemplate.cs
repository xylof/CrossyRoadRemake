using SDA.Generation;
using UnityEngine;

namespace SDA.Data
{
    [CreateAssetMenu(menuName = "Crossy/Lanes Template/New Template")]
    public class LanesTemplate : ScriptableObject
    {
        [SerializeField]
        public Lane[] lanes;
    }
}