using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : PickUp
{
    public float healValue; // how much the player heals

    public override void Activate()
    {
        player.health += healValue;
        if(player.health > player.maxHealth)
        {
            player.health = player.maxHealth;
        }
    }
}
