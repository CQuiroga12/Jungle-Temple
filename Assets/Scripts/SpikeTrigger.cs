using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrigger : MonoBehaviour
{
    private PlayerHealth playerHealth = null;
    public int damage;
    public float knockbackDuration;
    public float knockbackPowerX;
    public float knockbackPowerY;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (playerHealth == null)
        {
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("HIT HIT HIT");
            playerHealth.Damage(damage);


            StartCoroutine(playerHealth.Knockback(knockbackDuration,
            knockbackPowerX * Mathf.Sign((playerHealth.transform.position.x - collision.transform.position.x)), knockbackPowerY,
            playerHealth.transform.position));

            StartCoroutine(playerHealth.FlashRed());
            
        }
    }
}
