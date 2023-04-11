using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC_ScriptedInteraction : MonoBehaviour
{
    public float radius = 3f;
    public GameObject Canvas;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public TextMeshProUGUI nameComponent;
    public string name;
    public float textSpeed;
    private int index;
    public GameObject InteractButton;

//Hide items at the start
    void Start(){
        Canvas.SetActive(false);
        InteractButton.SetActive(false);
    }

//Show Interaction Buttons
    public void ShowButton(){
        InteractButton.SetActive(true);
        bool active = true;

        if(active == true){
            StartCoroutine(HideObject());
        }
    }

    IEnumerator HideObject() {
        // Wait for the specified number of seconds
        yield return new WaitForSeconds(2);
        InteractButton.SetActive(false);
    }

//Sphere Position (If Player is close)
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

//Interaction
    public void Interact() {
        Debug.Log("I'm an NPC!");
        Canvas.SetActive(true);
        nameComponent.text = name;
        DialogueStart();
    }

//Dialogue
    public void DialogueStart()
    {
        textComponent.text = string.Empty;

        StartDialogue();
    }

//Left click to go to next line
    public void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            if(textComponent.text == lines[index]){
                NextLine();
            }
            else{
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue(){
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray()){
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine(){
        if (index < lines.Length - 1){
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else {
            Canvas.SetActive(false);
        }
    }
}
