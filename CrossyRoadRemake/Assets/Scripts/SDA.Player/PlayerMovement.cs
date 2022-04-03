using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SDA.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private float distance = 1.5f;
        private bool canMove = true;

        public void MoveForward()
        {
            if (!canMove)
                return;

            canMove = false;
            Vector3 endPosition = transform.position + new Vector3(distance, 0, 0);
            transform.DORotate(new Vector3(0, 0, 0), 0.2f);
            transform.DOJump(endPosition, 1, 1, 0.2f).OnComplete(() => canMove = true);
        }

        public void MoveBackward()
        {
            if (!canMove)
                return;

            canMove = false;
            Vector3 endPosition = transform.position + new Vector3(-distance, 0, 0);
            transform.DORotate(new Vector3(0, 180, 0), 0.2f);
            transform.DOJump(endPosition, 1, 1, 0.2f).OnComplete(() => canMove = true);
        }

        public void MoveLeft()
        {
            if (!canMove)
                return;

            canMove = false;
            Vector3 endPosition = transform.position + new Vector3(0, 0, distance);
            transform.DORotate(new Vector3(0, -90, 0), 0.2f);
            transform.DOJump(endPosition, 1, 1, 0.2f).OnComplete(() => canMove = true);
        }

        public void MoveRight()
        {
            if (!canMove)
                return;

            canMove = false;
            Vector3 endPosition = transform.position + new Vector3(0, 0, -distance);
            transform.DORotate(new Vector3(0, 90, 0), 0.2f);
            transform.DOJump(endPosition, 1, 1, 0.2f).OnComplete(() => canMove = true);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Wall"))
            {
                Debug.Log("Die");
            }
        }
    }
}
