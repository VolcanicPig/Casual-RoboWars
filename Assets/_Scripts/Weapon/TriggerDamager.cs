using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VolcanicPig.Mobile;

namespace Game
{
    public class TriggerDamager : MonoBehaviour
    {
        [SerializeField] private Weapon weaponLink;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Health health))
            {
                ObjectPool.Instance.SpawnFromPool(weaponLink.EffectKey, null, other.ClosestPoint(transform.position),
                    Quaternion.identity);
                
                health.TakeHealth(weaponLink.Damage);

                if (other.TryGetComponent(out Rigidbody rb))
                {
                    Vector3 direction = (rb.position - transform.position).normalized;
                    rb.AddForce(direction * weaponLink.Knockback, ForceMode.Impulse); 
                }
            }
        }
    }
}
