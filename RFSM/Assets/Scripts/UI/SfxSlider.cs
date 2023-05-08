using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SfxSlider : MonoBehaviour
{
    public Slider slider;
    public TMP_Text valueText;

    void Start()
    {
        slider.value = SceneInfo.SfxValue;
        UpdateValueText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This method is called when the slider's value changes
    // put this to slider
    public void OnValueChanged()
    {
        SceneInfo.SfxValue = slider.value; // Update the music value in SceneInfo
        UpdateValueText();
    }


    private void UpdateValueText()
    {
        int percentage = Mathf.RoundToInt((slider.value + 50f) / 50f * 100f); // Update the value text with the percentage value
        valueText.text = percentage + "%"; 
    }
}
