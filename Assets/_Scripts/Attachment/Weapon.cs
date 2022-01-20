using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Weapon : MonoBehaviour
    {
        public WeaponSlot Slot => slotToFill; 
        [SerializeField] private WeaponSlot slotToFill;
    }
}
