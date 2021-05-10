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
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            playerHealth.Damage(damage);
            float xDirection = Mathf.Sign(playerHealth.transform.position.x - collision.GetContact(0).point.x);
            StartCoroutine(playerHealth.Knockback(knockbackDuration, knockbackPowerX * xDirection, knockbackPowerY));

            StartCoroutine(playerHealth.FlashRed());
        }
    }
}
