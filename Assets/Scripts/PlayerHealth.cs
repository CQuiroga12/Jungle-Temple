using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour

{
    public float hitPoints;
    public float currentHealth;
    public float stunnedTime;
    public Rigidbody2D rb2d;
    public SpriteRenderer sprite;
    public Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = hitPoints;
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        playerScript = GetComponent<Player>();
    }

    public void Damage(int dmg)
    {
        currentHealth -= dmg;
    }

    public IEnumerator Knockback(float knockbackDuration, float knockbackX, float knockbackY){

        float timer = 0.0f;
        
        while (knockbackDuration > timer){
            timer += Time.deltaTime;

            rb2d.AddForce(new Vector2(knockbackX, knockbackY));
        }

        yield return 0;
    }

    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        playerScript.stunned = true;
        yield return new WaitForSeconds(stunnedTime);
        sprite.color = Color.white;
        playerScript.stunned = false;
    }

}
