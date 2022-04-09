using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace SDA.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private float distance = 1.5f;
        private bool canMove = true;
        private UnityAction onDie;
        private UnityAction onOneStepForward;
        private UnityAction onOneStepBackward;
        private Vector3 startPos;

        public void InitPlayer()
        {
            startPos = transform.position;
        }

        public void MoveForward()
        {
            if (!canMove)
                return;

            canMove = false;
            Vector3 endPosition = transform.position + Vector3.right * distance;
            transform.DORotate(new Vector3(0, 90, 0), 0.2f);
            transform.DOJump(endPosition, 1, 1, 0.2f).OnComplete(() => canMove = true);

            onOneStepForward?.Invoke();
        }

        public void MoveBackward()
        {
            if (!canMove)
                return;

            canMove = false;
            Vector3 endPosition = transform.position + Vector3.right * -distance;
            transform.DORotate(new Vector3(0, 270, 0), 0.2f);
            transform.DOJump(endPosition, 1, 1, 0.2f).OnComplete(() => canMove = true);

            onOneStepBackward?.Invoke();
        }

        public void MoveLeft()
        {
            if (!canMove)
                return;

            canMove = false;
            Vector3 endPosition = transform.position + Vector3.forward * distance;
            transform.DORotate(new Vector3(0, 0, 0), 0.2f);
            transform.DOJump(endPosition, 1, 1, 0.2f).OnComplete(() => canMove = true);
        }

        public void MoveRight()
        {
            if (!canMove)
                return;

            canMove = false;
            Vector3 endPosition = transform.position + Vector3.forward * -distance;
            transform.DORotate(new Vector3(0, 180, 0), 0.2f);
            transform.DOJump(endPosition, 1, 1, 0.2f).OnComplete(() => canMove = true);
        }

        public void OnDieAddListener(UnityAction callback)
        {
            onDie = callback;
        }

        public void OnOneStepForwardAddListener(UnityAction callback)
        {
            onOneStepForward = callback;
        }

        public void OnOneStepBackwardAddListener(UnityAction callback)
        {
            onOneStepBackward = callback;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Wall"))
            {
                onDie.Invoke();
            }
            else if(other.CompareTag("Car"))
            {
                if (Math.Abs(transform.position.y - startPos.y) < 0.1f)
                {
                    transform.DOScaleY(0.05f, 0.1f);
                }

                onDie.Invoke();
            }
        }
    }
}
