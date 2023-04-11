using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NPCShopInteraction : MonoBehaviour
{
    public float radius = 3f;
    public GameObject Canvas;
    public GameObject ShopCanvas;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public TextMeshProUGUI nameComponent;
    public string name;
    public float textSpeed;
    private int shopIndex;
    public string scenename;
    public GameObject InteractButton;

    void Start(){
        Canvas.SetActive(false);
        ShopCanvas.SetActive(false);
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


    void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void ShopInteract() {
        Debug.Log("I'm the ShopKeeper!");
        Canvas.SetActive(true);
        nameComponent.text = name;
        DialogueStart();
        ShopShow();
    }
    public void ShopShow() {
        ShopCanvas.SetActive(true);
    }

    // Start is called before the first frame update
    public void DialogueStart()
    {
        textComponent.text = string.Empty;

        StartDialogue();
    }

    // Update is called once per frame
    public void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            if(textComponent.text == lines[shopIndex]){
                ShopNextLine();
            }
            else{
                StopAllCoroutines();
                textComponent.text = lines[shopIndex];
            }
        }
    }

    void StartDialogue(){
        shopIndex = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[shopIndex].ToCharArray()){
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void ShopNextLine(){
        if (shopIndex < lines.Length - 1){
            shopIndex++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else {
            Canvas.SetActive(false);
        }
    }
}
