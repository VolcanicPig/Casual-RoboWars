using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;

        private void Update()
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime; 
        }

        private void OnCollisionEnter(Collision other)
        {
            Destroy(gameObject); 
        }
    }
}
