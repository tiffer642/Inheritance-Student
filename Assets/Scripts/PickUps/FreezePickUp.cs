using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePickUp : PickUp
{
    public GameObject[] enemies;
    public override void Activate()
    {
        // Find all GameObjects with the "Enemy" tag
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Loop through each enemy and destroy it
        for (int i = 0; i < enemies.Length; i++)
        {
            GameObject enemy = enemies[i];
            enemy.GetComponent<Enemy>().speed = 0.0f;
        }
        StartCoroutine(ResetSpeed());
    }

    IEnumerator ResetSpeed()
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < enemies.Length; i++)
        {
            GameObject enemy = enemies[i];
            enemy.GetComponent<Enemy>().speed = enemy.GetComponent<Enemy>().defaultSpeed;
        }
    }
}
