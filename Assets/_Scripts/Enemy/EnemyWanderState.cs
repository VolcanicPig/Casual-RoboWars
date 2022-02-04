using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Game
{
    public class EnemyWanderState : EnemyState
    {
        private Transform _currentWaypoint;
        private bool _isGettingWaypoint; 
        
        public EnemyWanderState(Enemy enemyRef, Transform transformRef) : base(enemyRef, transformRef)
        {
        }

        public override void Start()
        {
            base.Start();
            GetWaypoint();
        }

        public override void Update()
        {
            base.Update();
            SearchForPlayer();

            if (_currentWaypoint)
            {
                MoveToWaypoint();
            }
        }

        private void SearchForPlayer()
        {
            List<GameObject> detected = enemy.RangeSensor.DetectedObjectsOrderedByDistance; 
            if (detected.Count == 0) return; 

            Player player = detected[0].GetComponent<Player>();
            enemy.SetState(new EnemyChaseState(enemy, transform, player));
        }

        private void GetWaypoint()
        {
            _currentWaypoint = enemy.Section.GetRandomWaypoint();
            _isGettingWaypoint = false; 
        }

        private async void WaitThenGetWaypoint(int waitTime)
        {
            _isGettingWaypoint = true; 
            await Task.Delay(waitTime * 1000); 
            GetWaypoint();
        }
        
        private void MoveToWaypoint()
        {
            if (_isGettingWaypoint) return; 
            
            Vector3 currPos = transform.position;
            float distance = Vector3.Distance(currPos, _currentWaypoint.position);

            if (distance > 1f)
            {
                Vector3 direction = _currentWaypoint.position - transform.position; 
                float angleToDirection = Vector3.Angle(transform.forward, direction);

                RotateToWaypoint(direction);
                
                if (angleToDirection <= 45)
                {
                    float step = 2f * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(currPos, _currentWaypoint.position, step); 
                }
            }
            else if(!_isGettingWaypoint)
            {
                WaitThenGetWaypoint(Random.Range(1, 6));
            }
        }
        
        private void RotateToWaypoint(Vector3 targetDir)
        {
            float step = 10f * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            Debug.DrawRay(transform.position, newDir, Color.red);
            transform.rotation = Quaternion.LookRotation(newDir); 
        }
    }
}