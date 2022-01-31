using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Section : MonoBehaviour
    {
        public static Action SectionCleared; 
        
        [Header("Section Settings")] 
        [SerializeField] private int enemiesToSpawn;

        [Header("References")]
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private Enemy enemyPrefab;
        [SerializeField] private GameObject blockade; 
        
        public List<Enemy> _enemies = new List<Enemy>();


        private void Start()
        {
            SpawnEnemies();
        }

        private void SpawnEnemies()
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Transform spawnPoint = spawnPoints[i];
                Enemy enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

                enemy.Init(this);
                _enemies.Add(enemy); 
            }
        }

        public void OnEnemyKilled(Enemy enemy)
        {
            if (_enemies.Contains(enemy))
            {
                _enemies.Remove(enemy); 
            }
            
            if (_enemies.Count == 0)
            {
                Debug.Log("Cleared Enemies");
                blockade.SetActive(false); 
                SectionCleared?.Invoke(); 
            }
        }
    }
}
