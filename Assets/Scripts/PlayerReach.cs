using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerReach : MonoBehaviour
{
    private List<KnockableObject> objectsInReach;
    [SerializeField] private int direction;

    private List<Interactable> interactables;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectsInReach = new List<KnockableObject>();
        interactables = new List<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.X)) {
            transform.parent.GetComponent<PlayerAnimation>().swipeAnimation();
            Vector2 playerVelocity = transform.parent.GetComponent<Rigidbody2D>().linearVelocity;
            foreach(KnockableObject ko in objectsInReach) {
                // ko.knockOver(direction + playerVelocity.x/4);
                ko.knockOver(playerVelocity, direction);
            }
            // objectsInReach.Clear();
            foreach(Interactable iobj in interactables) {
                iobj.interact();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        KnockableObject ko = collider.GetComponent<KnockableObject>();
        if(ko != null && !objectsInReach.Contains(ko)) {
            objectsInReach.Add(ko);
        }
        Interactable iobj = collider.GetComponent<Interactable>();
        if(iobj != null && !interactables.Contains(iobj)) {
            interactables.Add(iobj);
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        KnockableObject ko = collider.GetComponent<KnockableObject>();
        if(ko != null && objectsInReach.Contains(ko)) {
            objectsInReach.Remove(ko);
        }
        Interactable iobj = collider.GetComponent<Interactable>();
        if(iobj != null && interactables.Contains(iobj)) {
            interactables.Remove(iobj);
        }
    }
}
