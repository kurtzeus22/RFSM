using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    public Slider slider;
    public TMP_Text valueText; // Text component to display the value

    // Start is called before the first frame update
    void Start()
    {
        slider.value = SceneInfo.MusicValue;
        UpdateValueText();
    }

    // Update is called once per frame
    void Update()
    {
    }

    // This method is called when the slider's value changes
    public void OnValueChanged()
    {
        SceneInfo.MusicValue = slider.value; // Update the music value in SceneInfo
        UpdateValueText();
    }

    // Helper method to update the value text
    private void UpdateValueText()
    {
        int percentage = Mathf.RoundToInt((slider.value + 50f) / 50f * 100f);
        valueText.text = percentage + "%"; // Update the value text with the percentage value
    }
}
