using System.Collections;
using System.Collections.Generic;
using SensorToolkit;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
    public enum WeaponSlot
    {   
        Top, Front, Back, Side
    }
    
    public class PlayerWeaponController : SerializedMonoBehaviour
    {
        public Dictionary<WeaponSlot, GameObject> slotMap = new Dictionary<WeaponSlot, GameObject>(); 
        public Dictionary<WeaponSlot, Weapon> currentAttachments = new Dictionary<WeaponSlot, Weapon>();

        [SerializeField] private RangeSensor rangeSensor; 
        
        public void EquipWeapon(Weapon weapon)
        {
            Weapon newWeapon = Instantiate(weapon, slotMap[weapon.Slot].transform);
            newWeapon.Init(rangeSensor); 
            
            if (currentAttachments.ContainsKey(weapon.Slot))
            {
                Destroy(currentAttachments[weapon.Slot].gameObject);
                currentAttachments[weapon.Slot] = newWeapon; 
            }
            else
            {
                currentAttachments.Add(weapon.Slot, newWeapon);
            }
        }
    }
}
