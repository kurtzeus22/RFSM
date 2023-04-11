using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    // for focus mode
    //<focus>
    public Transform enemyTransform;
    public float focusSpeed = 5f;
    public float focusDistance = 10f;
    [SerializeField]
    private bool isFocused = false;
    //</focus>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isFocused = true;
        }

        if (isFocused)
        {
            if (enemyTransform == null)
            {
                isFocused = false;
                return;
            }

            Vector3 dirToEnemy = enemyTransform.position - transform.position;
            float distanceToEnemy = dirToEnemy.magnitude;

            if (distanceToEnemy > focusDistance)
            {
                isFocused = false;
                return;
            }

            Quaternion lookRotation = Quaternion.LookRotation(dirToEnemy);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * focusSpeed);
        }
    }
}
