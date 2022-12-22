using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // the maximum health the enemy can have
    public int currentHealth; // the current health the enemy has

    void Start()
    {
        currentHealth = maxHealth; // set the current health to the maximum health at the start of the game
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // reduce the current health by the damage taken

        if (currentHealth <= 0) // if the enemy's health is less than or equal to 0
        {
            Die(); // call the Die function
        }
    }

    void Die()
    {
        Destroy(gameObject); // destroy the enemy game object
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet") // if the enemy collides with a game object with the "Bullet" tag
        {
            TakeDamage(1); // take 1 damage
        }
    }
}
