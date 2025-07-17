using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MuffleArea : MonoBehaviour
{
    private List<KnockableObject> objectsInArea;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectsInArea = new List<KnockableObject>();
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    void OnTriggerEnter2D(Collider2D collider) {
        KnockableObject ko = collider.GetComponent<KnockableObject>();
        if(ko != null && !objectsInArea.Contains(ko)) {
            objectsInArea.Add(ko);
            ko.muffled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        KnockableObject ko = collider.GetComponent<KnockableObject>();
        if(ko != null && objectsInArea.Contains(ko)) {
            objectsInArea.Remove(ko);
            ko.muffled = false;
        }
    }
}
