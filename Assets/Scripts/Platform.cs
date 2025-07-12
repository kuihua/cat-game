using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Platform : MonoBehaviour
{
    private Collider2D platformCollider;
    private bool playerOnPlatform;
    private Collider2D playerCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        platformCollider = GetComponent<Collider2D>();
        // playerCollider = GameObject.Find("Player").GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerOnPlatform && Input.GetAxisRaw("Vertical") < 0) {
            Physics2D.IgnoreCollision(platformCollider, playerCollider, true);
            StartCoroutine(EnableCollision());
        }
    }

    private IEnumerator EnableCollision() {
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreCollision(platformCollider, playerCollider, false);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player")) {
            playerOnPlatform = true;
            playerCollider = collision.gameObject.GetComponent<Collider2D>();
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player")) {
            playerOnPlatform = false;
        }
    }
}
