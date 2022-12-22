using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // the maximum health the player can have
    public int currentHealth; // the current health the player has

    public Slider healthSlider; // reference to the health slider UI element
    public Text healthText; // reference to the health text UI element

    void Start()
    {
        currentHealth = maxHealth; // set the current health to the maximum health at the start of the game
        UpdateUI(); // update the UI elements
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // reduce the current health by the damage taken
        UpdateUI(); // update the UI elements

        if (currentHealth <= 0) // if the player's health is less than or equal to 0
        {
            Die(); // call the Die function
        }
    }

    void Die()
    {
        // handle the player's death, such as triggering a game over screen or respawning the player
    }

    void UpdateUI()
    {
        healthSlider.value = currentHealth; // set the value of the health slider to the current health
        healthText.text = currentHealth.ToString(); // set the text of the health text to the current health
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy") // if the player collides with an enemy game object
        {
            TakeDamage(1); // take 1 damage
        }
    }
}
