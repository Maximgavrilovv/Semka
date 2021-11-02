using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class MeleeWeapon : Weapon
    {
        public int attackRange;
        public double attackSpeed;

        MeleeWeapon()
        {
            type = "Melee";
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
