using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton
    public static Inventory Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory Found");
            return;
        }
        Instance = this;    
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;

    public List<Item> items = new List<Item>();
    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                Debug.Log("Not enough room");
                return false;
            }
            items.Add(item);

            if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();//trigger the event - update ui

        }
        return true;
    }
    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();//trigger the event - update ui
    }

}
