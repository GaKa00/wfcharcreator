using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfcharcreator
{
 internal class Weapon {
        public enum WeaponType {
           Melee,
           Primary,
           Secondary 
        }
        public string Name { get; set; }
        public WeaponType Type { get; set; }
        public string Damage { get; set; }
        public string DamageType { get; set; }
        public Weapon(string name, WeaponType type, string damage , string damageType) 
        { 
            Name = name;
            Type = type;
            Damage = damage;
            DamageType = damageType; }
    } 
}
