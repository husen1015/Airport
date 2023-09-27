using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SliderBehavior : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    private UnityEngine.UI.Slider slider;
    
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<UnityEngine.UI.Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void UpdateValue()
    {
        int updatedVal = (int)(slider.value * 400);
        Controller.numberOfPassengers = updatedVal;
        numberText.text = updatedVal.ToString();
    }
}
