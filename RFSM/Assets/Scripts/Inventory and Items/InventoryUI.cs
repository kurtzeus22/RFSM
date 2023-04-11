using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;

    Inventory inventory;

    InventorySlot[] slots;

    void Start()
    {
        //for initialization
        inventory = Inventory.Instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots =  itemsParent.GetComponentsInChildren<InventorySlot>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            //press 'i' or 'b' to show inventory
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }
    void UpdateUI()
    {
        Debug.Log("Updating UI.....");
        for(int i = 0; i < slots.Length; i++)
        {
            if(i<inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot(); 
            }
        }
    }
}
