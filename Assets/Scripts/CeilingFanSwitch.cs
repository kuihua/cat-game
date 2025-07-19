using UnityEngine;

public class CeilingFanSwitch : Interactable
{
    [SerializeField] private CeilingFan fan;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void interact() {
        if(fan.GetComponent<Collider2D>().enabled) {
            fan.turnOff();
        }
        else{
            fan.turnOn();
        }
        Debug.Log("switch");
    }
}
