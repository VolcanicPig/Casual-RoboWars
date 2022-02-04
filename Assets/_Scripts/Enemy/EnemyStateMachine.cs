using UnityEngine;

namespace Game
{
    public class EnemyStateMachine : MonoBehaviour
    {
        protected EnemyState state;

        public void SetState(EnemyState newState)
        {
            state = newState; 
            state.Start();
        }
    }
}