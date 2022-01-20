using UnityEngine;
using VolcanicPig.Collectable;

namespace Game
{
    public class WeaponCollectable : Collectable
    {
        [SerializeField] private Weapon weapon; 
        
        public override void Collect(GameObject player)
        {
            PlayerWeaponController weaponController = player.GetComponent<PlayerWeaponController>(); 
            weaponController.EquipWeapon(weapon);
            
            base.Collect(player);
        }
    }
}