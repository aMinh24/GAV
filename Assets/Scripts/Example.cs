using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    public Toggle toggle;
    public Slider slider;
    public TMP_Dropdown dropdown;

    private void Awake()
    {
        Debug.Log("aa");
    }
    public void OnClickedButton()
    {
        Debug.Log("button is clicked");
    }    
    public void OnValueChangeToggle()
    {
        if (toggle.isOn) Debug.Log("True");
        else Debug.Log("False");
    }  
    public void OnValueChangedSlider()
    {
        Debug.Log("Value: "+slider.value);
    }    
    public void OnValueChangedDropdown(int value)
    {
        Debug.Log(value);
    }    
}
