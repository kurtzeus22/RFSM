using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform player;
    public Transform interactableTransform;
    bool hasInteracted = false;

    public virtual void Interact()
    {
        //this method is to be overwritten
        Debug.Log("Interacting with " + interactableTransform.name);


    }
    private void Update()
    {
        if (!hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactableTransform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactableTransform.position, radius);
    }

}
  