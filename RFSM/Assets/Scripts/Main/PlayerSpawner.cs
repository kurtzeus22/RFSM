using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private void Start()
    {
        Instantiate(GameManager.instance.currentCharacter.prefab, transform.position, Quaternion.identity);
    }
}
