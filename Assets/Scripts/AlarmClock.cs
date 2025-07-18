using UnityEngine;

public class AlarmClock : MonoBehaviour
{
    float timeItRingsFor = 10;
    float ringCycleTime = 60;
    float timer = 30;
    bool ringing = false;

    // // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(!ringing && timer > ringCycleTime) {
            timer = 0;
            ringing = true;
            Meter.instance.addValue(30);
            Meter.instance.increaseMinValue(30);
        }
        else if(ringing && timer > timeItRingsFor) {
            ringing = false;
            Meter.instance.increaseMinValue(-30);
        }
    }
}
