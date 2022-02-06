using System.Collections;
using System.Collections.Generic;
using SensorToolkit;
using UnityEngine;

namespace Game
{
    public class Weapon : MonoBehaviour
    {
        public WeaponSlot Slot => slotToFill;
        public int Damage => damage;
        public float Knockback => knockbackForce;  
        public string EffectKey => hitEffectKey; 
        
        [SerializeField] private WeaponSlot slotToFill;
        [SerializeField] protected int damage;
        [SerializeField] protected string hitEffectKey;
        [SerializeField] protected float knockbackForce;
        
        protected RangeSensor rangeSensor;

        public void Init(RangeSensor newRangeSensor)
        {
            transform.localPosition = Vector3.zero;
            rangeSensor = newRangeSensor; 
        }
        
        protected virtual void Attack() { }
    }
}
