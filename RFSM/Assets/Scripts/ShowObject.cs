using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObject : MonoBehaviour
{
    [Header("Drag Object you want to show")]
    [SerializeField]private GameObject[] showableObject;
    [Header("If you want to destroy or hide after collision")]
    [SerializeField] bool destroy;
    [SerializeField] bool Hide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        foreach (GameObject obj in showableObject)
        {
            obj.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            if(destroy)
            {
                Destroy(gameObject);
            }
            if(Hide)
            {
                gameObject.SetActive(false);
            }
    }
}
