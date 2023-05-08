using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameLoading : MonoBehaviour
{

    public TMP_Text phraseText;
    [Header ("Enter quotes here")]
    public string[] phrases;

    [Space]
    [Header("Choose colors")]
    public Color[] colors;

    [Space]
    public Image imageToChange;

    void OnEnable()
    {
        RandomText();
        RandomColor();
    }
    public void RandomText()
    {
        // Set the text on the game loading to random text from the phrases array
        phraseText.text = phrases[Random.Range(0, phrases.Length)];
    }

    public void RandomColor()
    {
        // Pick a random color from the colors array
        int randomColorIndex = Random.Range(0, colors.Length);
        Color randomColor = colors[randomColorIndex];

        // Set the color of the game loading background to the random color
        imageToChange.color = randomColor;
    }
}
