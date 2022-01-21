using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class TurretWeapon : Weapon
    {
        [SerializeField] private float rotateSpeed;
        [SerializeField] private float minAngleToShoot;

        private void Update()
        {
            if (rangeSensor.DetectedObjects.Count == 0) return;
            RotateToTarget();
        }

        private void RotateToTarget()
        {
            GameObject currentTarget = rangeSensor.DetectedObjects[0]; 
            
            float step = rotateSpeed * Time.deltaTime;
            Vector3 targetDir = currentTarget.transform.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection); 
        }
    }
}
