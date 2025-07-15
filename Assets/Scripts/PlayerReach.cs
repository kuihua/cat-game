using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerReach : MonoBehaviour
{
    private List<KnockableObject> objectsInReach;
    [SerializeField] private int direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectsInReach = new List<KnockableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            Vector2 playerVelocity = transform.parent.GetComponent<Rigidbody2D>().linearVelocity;
            foreach(KnockableObject ko in objectsInReach) {
                // ko.knockOver(direction + playerVelocity.x/4);
                ko.knockOver(playerVelocity, direction);
            }
            // objectsInReach.Clear();
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        KnockableObject ko = collider.GetComponent<KnockableObject>();
        // if(ko != null && !ko.knockedOver && !objectsInReach.Contains(ko)) {
        if(ko != null && !objectsInReach.Contains(ko)) {
            objectsInReach.Add(ko);
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        KnockableObject ko = collider.GetComponent<KnockableObject>();
        if(ko != null && objectsInReach.Contains(ko)) {
            objectsInReach.Remove(ko);
        }
    }
}
