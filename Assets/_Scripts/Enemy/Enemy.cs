using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Enemy : MonoBehaviour
    {
        public Health Health { get; private set; }
        
        [SerializeField] private GameObject deathParticle;

        private Section _section; 

        private void Awake()
        {
            Health = GetComponent<Health>();
            Health.Killed += OnDeath; 
        }

        private void OnDisable()
        {
            Health.Killed -= OnDeath; 
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Health.TakeHealth(1);
            }
        }

        public void Init(Section section)
        {
            _section = section; 
        }

        private void OnDeath()
        {
            _section.OnEnemyKilled(this); 
            Instantiate(deathParticle, transform.position, Quaternion.identity); 
        }
    }
}
