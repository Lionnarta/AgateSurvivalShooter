using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    public AudioClip soundEffect;
    public int healthRecover = 20;
    GameObject player;
    PlayerHealth playerHealth;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other is CapsuleCollider)
        {
            AudioSource.PlayClipAtPoint(soundEffect, transform.position);

            // Effect
            if (playerHealth.currentHealth + healthRecover > playerHealth.startingHealth)
            {
                playerHealth.currentHealth = playerHealth.startingHealth;
                playerHealth.healthSlider.value = playerHealth.startingHealth;
            }
            else
            {
                playerHealth.currentHealth += healthRecover;
                playerHealth.healthSlider.value = playerHealth.currentHealth;
            }

            // Destroy power up when pick up
            Destroy(gameObject);
        }
    }
}
