using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NavGame.Core
{
    public class CombatGameObject : MonoBehaviour
    {

        float cooldown = 0f;
        

        protected virtual void Update()
        {
            DecreaseAttackCooldown();
        }
        public void AttackOnCooldown(DamageableGameObject target)
        {
            if (cooldown <= 0f)
            {
                cooldown = 1f / Stats.attackSpeed;
                target.TakeDamage(Stats.damage);
            }

            vooid DecreaseAttackCooldown()
            {
                if (cooldown == 0f)
                {
                    return;
                }
                cooldown -= Time.deltaTime;
                if (cooldown < 0f)
                {
                    cooldown = 0f;
                }
            }
        }
    }
}