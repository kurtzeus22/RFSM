using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DisableItem : MonoBehaviour
{
    public GameObject Images;

    public void OnPointerClick(PointerEventData eventData)
    {
        Images.SetActive(false);
    }
}
