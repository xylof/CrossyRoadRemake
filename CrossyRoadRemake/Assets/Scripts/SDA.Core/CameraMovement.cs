using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SDA.Core
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField]
        private float speed;

        public void UpdateCameraPosition()
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
    } 
}
