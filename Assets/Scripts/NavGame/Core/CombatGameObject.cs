﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NavGame.Managers;

namespace NavGame.Core
{
    public class CombatGameObject : DamageableGameObject
    {

        float cooldown = 0f;

        public OnAttackHitEvent onAttackHit;

        protected virtual void Update()
        {
            DecreaseAttackCooldown();
        }
        public void AttackOnCooldown(DamageableGameObject target)
        {
            if (cooldown <= 0f)
            {
                cooldown = 1f / stats.attackSpeed;
                target.TakeDamage(stats.damage);
                if (onAttackHit != null)
                {
                    onAttackHit(target.transform.position);
                }

            }
        }

        void DecreaseAttackCooldown()
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
