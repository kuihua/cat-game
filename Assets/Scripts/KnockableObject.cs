using UnityEngine;

public class KnockableObject : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool recordVelocity = false;
    private Vector2 previousVelocity;
    private Vector2 lastRecordedVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) {
            knockOver(1);
        }

        if(recordVelocity) {
            if(lastRecordedVelocity != null) {
                previousVelocity = lastRecordedVelocity;
            }
            lastRecordedVelocity = rb.linearVelocity;
        }
    }

    public void knockOver(float direction) {
        PlatformCollisions.instance.disableCollisionWith(GetComponent<Collider2D>());
        rb.AddForce(new Vector2(direction, 0), ForceMode2D.Impulse);
        rb.AddTorque(-1 * direction, ForceMode2D.Impulse);
        recordVelocity = true;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.name == "Floor") {
            Debug.Log(previousVelocity.magnitude + " " + rb.linearVelocity.magnitude);
            Meter.instance.addValue(previousVelocity.magnitude);
        }
    }
}
