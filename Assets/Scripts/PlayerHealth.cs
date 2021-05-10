using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour

{
    public float hitPoints;
    public float currentHealth;
    public float stunnedTime;
    public Rigidbody2D rb2d;
    public Transform thisTransform;
    public SpriteRenderer sprite;
    public Player playerScript;
    public Color thisColor;
    public GameObject checkPoint;
    public scoreCount scoreCount;

    // Start is called before the first frame update
    void Start()
    {
        thisColor = sprite.color;
        currentHealth = hitPoints;
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        playerScript = GetComponent<Player>();
        thisTransform = GetComponent<Transform>();
        scoreCount = FindObjectOfType<scoreCount>();
    }

    private void Update()
    {
        if(scoreCount.gameLost)
        {
            StartCoroutine(FlashRed());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("CheckPoint"))
        {
            checkPoint = collision.gameObject;
        }
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
        sprite.color = thisColor;
        playerScript.stunned = false;
        yield return new WaitForSeconds(0.05f);
        thisTransform.position = checkPoint.transform.position;
    }

}
