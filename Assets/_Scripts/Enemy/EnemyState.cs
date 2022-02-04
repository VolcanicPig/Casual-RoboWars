using UnityEngine;

namespace Game
{
    public abstract class EnemyState
    {
        protected Enemy enemy;
        protected Transform transform; 

        public EnemyState(Enemy enemyRef, Transform transformRef)
        {
            enemy = enemyRef;
            transform = transformRef; 
        }

        public virtual void Start()
        {
            Debug.Log($"Entering State : {GetType().Name}");
        }

        public virtual void Update()
        {
            
        }
    }
}
