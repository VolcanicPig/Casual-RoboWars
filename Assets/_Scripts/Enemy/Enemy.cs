using System;
using System.Collections;
using System.Collections.Generic;
using SensorToolkit;
using UnityEngine;

namespace Game
{
    public class Enemy : EnemyStateMachine
    {
        public Health Health { get; private set; }
        public Section Section { get; private set; }
        public RangeSensor RangeSensor => rangeSensor;
        public EnemyStats Stats => enemyStats; 
        
        [SerializeField] private EnemyStats enemyStats;
        [SerializeField] private RangeSensor rangeSensor; 
        [SerializeField] private GameObject deathParticle;


        private void Awake()
        {
            Health = GetComponent<Health>();
            Health.Killed += OnDeath;

            rangeSensor.SensorRange = enemyStats.SightRange;
        }

        private void OnDisable()
        {
            Health.Killed -= OnDeath; 
        }

        private void Update()
        {
            state?.Update();
        }

        public void Init(Section section)
        {
            Section = section; 
            SetState(new EnemyWanderState(this, transform));
        }

        private void OnDeath()
        {
            Section.OnEnemyKilled(this); 
            Instantiate(deathParticle, transform.position, Quaternion.identity); 
        }
    }
}
