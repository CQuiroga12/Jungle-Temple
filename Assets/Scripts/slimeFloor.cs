using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeFloor : MonoBehaviour
{
    public float launchForce;
    public Animator animator;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * launchForce;
            animator.SetBool("Bounce", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("Bounce", false);
    }
}
