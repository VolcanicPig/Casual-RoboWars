using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class TurretWeapon : Weapon
    {
        [Header("Turret Movement")]
        [SerializeField] private GameObject turretTop; 
        [SerializeField] private float rotateSpeed;
        [SerializeField] private float minAngleToShoot;

        [Header("Shooting")]
        [SerializeField] private Transform projectileSpawnPoint;
        [SerializeField] private float shootCooldown;
        [SerializeField] private Projectile projectile;
        
        
        private GameObject _currentTarget; 
        private Vector3 _currentTargetDirection;
        private float _lastShotTime; 

        private void Update()
        {
            if (rangeSensor.DetectedObjects.Count == 0) return;
            RotateToTarget();
            CheckShoot();
        }

        private void CheckShoot()
        {
            float angle = Vector3.Angle(turretTop.transform.forward, _currentTargetDirection);
            if (angle < minAngleToShoot)
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            if (Time.time > _lastShotTime + shootCooldown)
            {
                Projectile p = Instantiate(projectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
                _lastShotTime = Time.time; 
            }
        }

        private void RotateToTarget()
        {
            _currentTarget = rangeSensor.DetectedObjects[0]; 
            
            float step = rotateSpeed * Time.deltaTime;
            _currentTargetDirection = _currentTarget.transform.position - turretTop.transform.position;
            Vector3 newDirection = Vector3.RotateTowards(turretTop.transform.forward, _currentTargetDirection, step, 0.0f);
            turretTop.transform.rotation = Quaternion.LookRotation(newDirection); 
        }
    }
}
