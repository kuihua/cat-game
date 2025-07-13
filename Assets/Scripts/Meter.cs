using UnityEngine;
using UnityEngine.UI;

public class Meter : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private readonly float MAX_VALUE = 100;
    private readonly float METER_MIN_VALUE = 0;
    private float minValue;
    private float decrementRate = 5;

    public static Meter instance {get; private set;}

    private bool awake = false;

    void Awake() {
        if(instance == null) {
            instance = this;
        }
        minValue = METER_MIN_VALUE;
        slider.maxValue = MAX_VALUE;
        slider.minValue = METER_MIN_VALUE;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float decrement = decrementRate * Time.deltaTime;
        addValue(-decrement);
    }

    public void addValue(float increment) {
        if(!awake) {
            float newValue = slider.value + increment;
            if(newValue > MAX_VALUE) {
                newValue = MAX_VALUE;
                awake = true;
            }
            else if(newValue < minValue) {
                newValue = minValue;
            }
            slider.value = newValue;
        }
    }

    public void increaseMinValue(float increment) {
        minValue += increment;
        if(minValue < METER_MIN_VALUE) {
            minValue = METER_MIN_VALUE;
        }
    }
}
