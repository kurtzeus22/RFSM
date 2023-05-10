using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionUI : MonoBehaviour
{
    public GameObject optionPrefab;

    public Transform prevCharacter;
    public Transform selectedCharacter;
    public GameObject PlayerBoy;
    public GameObject PlayerGirl;

    private void Start()
    {
        foreach (Character c in GameManager.instance.characters)
        {
            GameObject option = Instantiate(optionPrefab, transform);
            Button button = option.GetComponent<Button>();

            button.onClick.AddListener(() =>
            {
                
                GameManager.instance.SetCharacter(c);
                if (selectedCharacter != null)
                {
                    prevCharacter = selectedCharacter;
                }
                selectedCharacter = option.transform;
            });

            Text text = option.GetComponentInChildren<Text>();
            text.text = c.name;
        }
    }

    private void Update()
    {
        if (selectedCharacter != null)
        {
            
            //selectedCharacter.localScale = Vector3.Lerp(selectedCharacter.localScale, new Vector3(1.3f, 1.2f, 1.2f), Time.deltaTime * 10);
        }

        if (prevCharacter != null)
        {
            //prevCharacter.localScale = Vector3.Lerp(prevCharacter.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10);
        }

        if(PlayerBoy.activeSelf){
            Movement.PlayerSkin = 1;
            Debug.Log("Player Boy");
        }
        else if(PlayerGirl.activeSelf){
            Movement.PlayerSkin = 2;
            Debug.Log("Player Girl");
        }
    }
}
