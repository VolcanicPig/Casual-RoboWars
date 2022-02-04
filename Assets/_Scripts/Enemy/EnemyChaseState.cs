using UnityEngine;

namespace Game
{
    public class EnemyChaseState : EnemyState
    {
        private Player _player; 
        
        public EnemyChaseState(Enemy enemyRef, Transform transformRef, Player player) : base(enemyRef, transformRef)
        {
            _player = player; 
        }

        public override void Update()
        {
            base.Update();
            ChasePlayer();
        }

        private void ChasePlayer()
        {
            if (!_player) return;
            RotateToPlayer();
            
            Vector3 currPos = transform.position;
            Vector3 direction = _player.transform.position - currPos; 
            float angleToDirection = Vector3.Angle(transform.forward, direction);

            if (angleToDirection <= 45)
            {
                float step = enemy.Stats.ChaseSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(currPos, _player.transform.position, step); 
            }
        }
        
        private void RotateToPlayer()
        {
            Vector3 playerDir = _player.transform.position - transform.position; 
            
            float step = enemy.Stats.RotateSpeed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, playerDir, step, 0.0f);
            Debug.DrawRay(transform.position, newDir, Color.red);
            transform.rotation = Quaternion.LookRotation(newDir); 
        }
    }
}