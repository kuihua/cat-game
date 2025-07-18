using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private string currentState;

    private Rigidbody2D rb;
    bool swipe = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!swipe) {
            if(rb.linearVelocity.y > 0.1) {
                ChangeAnimationState("Cat_Jump");
            }
            else if(rb.linearVelocity.y < -0.1) {
                ChangeAnimationState("Cat_Fall");
            }
            else if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.1) {
                ChangeAnimationState("Cat_Walk");
            }
            else {
                ChangeAnimationState("Cat_Idle");
            }
        }
    }

    public void swipeAnimation() {
        ChangeAnimationState("Cat_Swipe");
        swipe = true;
    }

    public void finishSwipe() {
        swipe = false;
    }

    public void ChangeAnimationState(string newState) {
        if(currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }
}
