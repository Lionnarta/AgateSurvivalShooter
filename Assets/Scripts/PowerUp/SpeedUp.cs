using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public AudioClip soundEffect;
    public float speedMultiplier = 1.5f;
    public float duration = 5f;
    GameObject player;
    PlayerMovement playerMovement;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other is CapsuleCollider)
        {
            StartCoroutine(PickUp());
        }
    }

    IEnumerator PickUp()
    {
        AudioSource.PlayClipAtPoint(soundEffect, transform.position);

        // Effect
        playerMovement.speed *= speedMultiplier;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        playerMovement.speed /= speedMultiplier;

        // Destroy power up when pick up
        Destroy(gameObject);
    }
}
