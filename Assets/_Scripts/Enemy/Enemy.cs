using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private GameObject deathParticle;

        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
            _health.Killed += OnDeath; 
        }

        private void OnDisable()
        {
            _health.Killed -= OnDeath; 
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                _health.TakeHealth(1);
            }
        }

        private void OnDeath()
        {
            Instantiate(deathParticle, transform.position, Quaternion.identity); 
        }
    }
}
