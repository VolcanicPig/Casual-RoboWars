using UnityEngine;
using VolcanicPig.Mobile;

namespace Game
{
    public class MeleeWeapon : Weapon
    {
        [SerializeField] private int damage;
        [SerializeField] private float knockbackForce; 
        [SerializeField] private string hitEffectKey;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Health health))
            {
                ObjectPool.Instance.SpawnFromPool(hitEffectKey, null, other.ClosestPoint(transform.position),
                    Quaternion.identity);
                
                health.TakeHealth(damage);

                if (other.TryGetComponent(out Rigidbody rb))
                {
                    Vector3 direction = (rb.position - transform.position).normalized;
                    rb.AddForce(direction * knockbackForce, ForceMode.Impulse); 
                }
            }
        }
    }
}
