using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VolcanicPig.Mobile;

namespace Game
{
    public class TurretWeapon : Weapon
    {
        [Header("Turret Movement")]
        [SerializeField] private GameObject turretTop; 
        [SerializeField] private float rotateSpeed;
        [SerializeField] private float minAngleToShoot;
        [SerializeField] private Vector3 aimOffset; 

        [Header("Shooting")]
        [SerializeField] private Transform projectileSpawnPoint;
        [SerializeField] private float shootCooldown;
        [SerializeField] private string projectileKey;
        
        
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
                string parentLayerName = LayerMask.LayerToName(transform.parent.gameObject.layer); 
                ObjectPool.Instance.SpawnFromPool(
                    projectileKey, null, projectileSpawnPoint.position, projectileSpawnPoint.rotation, parentLayerName);
                
                _lastShotTime = Time.time; 
            }
        }

        private void RotateToTarget()
        {
            _currentTarget = rangeSensor.DetectedObjects[0];
            Vector3 targetPosition = _currentTarget.transform.position + aimOffset; 
            
            float step = rotateSpeed * Time.deltaTime;
            _currentTargetDirection = targetPosition - turretTop.transform.position;
            Vector3 newDirection = Vector3.RotateTowards(turretTop.transform.forward, _currentTargetDirection, step, 0.0f);
            turretTop.transform.rotation = Quaternion.LookRotation(newDirection); 
        }
    }
}
