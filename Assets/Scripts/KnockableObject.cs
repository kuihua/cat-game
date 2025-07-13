using UnityEngine;

public class KnockableObject : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool knockedOver {get; private set;}
    private Vector2 previousVelocity;
    private Vector2 lastRecordedVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        knockedOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.E)) {
        //     knockOver(1);
        // }

        if(knockedOver) {
            if(lastRecordedVelocity != null) {
                previousVelocity = lastRecordedVelocity;
            }
            lastRecordedVelocity = rb.linearVelocity;
        }
    }

    public void knockOver(float direction) {
        PlatformCollisions.instance.disableCollisionWith(GetComponent<Collider2D>());
        rb.AddForce(new Vector2(direction * 5, 0), ForceMode2D.Impulse);
        rb.AddTorque(-1 * direction, ForceMode2D.Impulse);
        knockedOver = true;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        // if(collision.gameObject.name == "Floor") {
        //     Debug.Log(previousVelocity.magnitude + " " + rb.linearVelocity.magnitude);
        Meter.instance.addValue(previousVelocity.magnitude);
        // }
    }
}
