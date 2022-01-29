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
            
            Recycle();
        }
    }
}
