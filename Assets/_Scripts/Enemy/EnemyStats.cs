using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "Enemy Stats", menuName = "Scriptable Objects/Enemy Stats")]
    public class EnemyStats : ScriptableObject
    {
        public int MaxHealth;
        public float SightRange;

        [Header("Movement")] 
        public float WanderSpeed;
        public float ChaseSpeed;
        public float RotateSpeed; 
    }
}
