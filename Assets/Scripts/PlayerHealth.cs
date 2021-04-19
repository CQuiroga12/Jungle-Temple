using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour

{
    public float hitPoints;
    public float currentHealth;
    public float flashTime;
    public Collider2D playerHeadCollider;
    public Collider2D playerFeetCollider;
    public Rigidbody2D rb2d;
    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = hitPoints;
    }

    public void Damage(int dmg)
    {
        currentHealth -= dmg;
    }

    public IEnumerator Knockback(float knockbackDuration, float knockbackPowerX, float knockbackPowerY, Vector2 knockbackDirection){

        float timer = 0;
        while(knockbackDuration > timer){
            timer += Time.deltaTime;
            rb2d.AddForce(new Vector2(knockbackDirection.x * knockbackPowerX, knockbackDirection.y * knockbackPowerY));
        }

        yield return 0;
    }

    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(flashTime);
        sprite.color = Color.white;
    }

}
