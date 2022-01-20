using System.Collections;
using System.Collections.Generic;
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

        public void EquipWeapon(Weapon weapon)
        {
            Weapon newWeapon = Instantiate(weapon, slotMap[weapon.Slot].transform);
            newWeapon.transform.localPosition = Vector3.zero; 
            
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
