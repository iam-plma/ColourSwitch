﻿using UnityEngine;
using Managers;

namespace CameraScripts
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField]
        private Transform target;

        private float cameraSpeed = 0.3f;
        private Vector3 currentVelocity;

        private void LateUpdate()
        {
            if (!GameManager.Instance.playerAlive)
                return;

            if (target.position.y > transform.position.y)
            {
                Vector3 newPosition = new Vector3(transform.position.x, target.position.y, transform.position.z);
                transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref currentVelocity, cameraSpeed * Time.deltaTime);
            }
        }
    }
}
