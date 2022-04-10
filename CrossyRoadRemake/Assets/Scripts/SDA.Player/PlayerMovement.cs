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
        private UnityAction onJump;
        private UnityAction onOneStepForward;
        private UnityAction onOneStepBackward;
        private Vector3 startPos;
        private bool IsDead = false;

        public void InitPlayer()
        {
            startPos = transform.position;
        }

        public void MoveForward()
        {
            if (!canMove)
                return;

            if (Physics.Raycast(transform.position, Vector3.right, 1.5f, 64))
                return;

            canMove = false;
            Vector3 endPosition = transform.position + Vector3.right * distance;
            transform.DORotate(new Vector3(0, 90, 0), 0.2f);
            transform.DOJump(endPosition, 1, 1, 0.2f).OnComplete(() => canMove = true);

            onOneStepForward?.Invoke();
            onJump?.Invoke();
        }

        public void MoveBackward()
        {
            if (!canMove)
                return;

            if (Physics.Raycast(transform.position, Vector3.left, 1.5f, 64))
                return;

            canMove = false;
            Vector3 endPosition = transform.position + Vector3.left * distance;
            transform.DORotate(new Vector3(0, 270, 0), 0.2f);
            transform.DOJump(endPosition, 1, 1, 0.2f).OnComplete(() => canMove = true);

            onOneStepBackward?.Invoke();
            onJump?.Invoke();

        }

        public void MoveLeft()
        {
            if (!canMove)
                return;

            if (Physics.Raycast(transform.position, Vector3.forward, 1.5f, 64))
                return;

            canMove = false;
            Vector3 endPosition = transform.position + Vector3.forward * distance;
            transform.DORotate(new Vector3(0, 0, 0), 0.2f);
            transform.DOJump(endPosition, 1, 1, 0.2f).OnComplete(() => canMove = true);

            onJump?.Invoke();
        }

        public void MoveRight()
        {
            if (!canMove)
                return;

            if (Physics.Raycast(transform.position, Vector3.back, 1.5f, 64))
                return;

            canMove = false;
            Vector3 endPosition = transform.position + Vector3.back * distance;
            transform.DORotate(new Vector3(0, 180, 0), 0.2f);
            transform.DOJump(endPosition, 1, 1, 0.2f).OnComplete(() => canMove = true);

            onJump?.Invoke();
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

        public void OnJumpAddListener(UnityAction callback)
        {
            onJump = callback;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (IsDead)
                return;

            if (other.CompareTag("Wall"))
            {
                onDie.Invoke();
                IsDead = true;
            }
            else if(other.CompareTag("Car"))
            {
                if (Math.Abs(transform.position.y - startPos.y) < 0.1f)
                {
                    transform.DOScaleY(0.05f, 0.1f);
                }

                onDie.Invoke();
                IsDead = true;
            }
        }
    }
}
