using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CeilingFan : MonoBehaviour
{
    private List<Rigidbody2D> rbs;

    private Animator animator;
    private string currentState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbs = new List<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Rigidbody2D rb in rbs) {
            rb.AddForce(Vector2.down * 10, ForceMode2D.Force);
        }
    }

    public void turnOn() {
        ChangeAnimationState("CeilingFan_On");
        GetComponent<Collider2D>().enabled = true;
    }

    public void turnOff() {
        ChangeAnimationState("CeilingFan_Off");
        GetComponent<Collider2D>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collider) {
        Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
        if(rb != null && !rbs.Contains(rb)) {
            rbs.Add(rb);
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
        if(rb != null && rbs.Contains(rb)) {
            rbs.Remove(rb);
        }
    }

    public void ChangeAnimationState(string newState) {
        if(currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }
}
