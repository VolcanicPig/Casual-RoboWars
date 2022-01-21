using System.Collections;
using System.Collections.Generic;
using SensorToolkit;
using UnityEngine;

namespace Game
{
    public class Weapon : MonoBehaviour
    {
        public WeaponSlot Slot => slotToFill; 
        [SerializeField] private WeaponSlot slotToFill;

        protected RangeSensor rangeSensor; 
        
        public void Init(RangeSensor newRangeSensor)
        {
            transform.localPosition = Vector3.zero;
            rangeSensor = newRangeSensor; 
        }
        
        protected virtual void Attack() { }
    }
}
