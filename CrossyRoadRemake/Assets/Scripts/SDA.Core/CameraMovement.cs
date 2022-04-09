using DG.Tweening;
using UnityEngine;

namespace SDA.Core
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField]
        private float speed;

        [SerializeField]
        private float catchupSpeed;

        [SerializeField]
        private Transform cameraDistancer;

        [SerializeField]
        private Transform player;

        [SerializeField]
        private int treshold;

        private bool duringCatching = false;

        public void UpdateCameraPosition()
        {
            float distance = Mathf.Abs(player.position.x - cameraDistancer.position.x);

            if (distance > treshold && !duringCatching)
            {
                transform.DOMove(transform.position + Vector3.right * catchupSpeed, 1f).OnComplete(() => duringCatching = false);
                duringCatching = true;
                return;
            }

            if (duringCatching)
                return;

            transform.position += Vector3.right * Time.deltaTime * speed;
        }
    }
}
