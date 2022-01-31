using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VolcanicPig.Mobile;

namespace Game
{
    public class Projectile : PooledObjectBase
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private int damage;
        [SerializeField] private string explosionEffectKey; 
        
        private void Update()
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime; 
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out Health health))
            {
                health.TakeHealth(damage); 
            }

            ObjectPool.Instance.SpawnFromPool(explosionEffectKey, null, transform.position, transform.rotation); 
            
            Recycle();
        }
    }
}
