using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFieldOfView : MonoBehaviour
{
    [Header("Attack Range")]
    public float radius;
    [Range(0, 360)]
    public  float angle;

    [Header("Game Object")]
    public GameObject enemyRef;

    [Header("Layer Mask")]
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private LayerMask obstructionMask;

    [Header("Boolean")]
    public bool canSeeEnemy;

    private void Start()
    {
        StartCoroutine(FovRoutine());
    }
    private IEnumerator FovRoutine()
    {
        WaitForSeconds delay = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return delay;
            enemyFieldOfViewCheck();
        }
    }
    private void enemyFieldOfViewCheck()
    {
        Collider[] enemyRangeChecks = Physics.OverlapSphere(transform.position, radius, enemyMask);

        if (enemyRangeChecks.Length != 0)
        {
            Transform closestEnemy = GetClosestEnemy(enemyRangeChecks);

            /*for (int i = 0; i <= enemyRangeChecks.Length; i++)
            {
                canSeeEnemy = true;
                enemyRef = enemyRangeChecks[i].gameObject;
                break;
            }*/

            if (closestEnemy != null)
            {
                canSeeEnemy = true;
                enemyRef = closestEnemy.gameObject;

                Transform enemy = enemyRef.transform;
                Vector3 playerDirectionToEnemy = (enemy.position - transform.position).normalized;
                if (Vector3.Angle(transform.forward, playerDirectionToEnemy) < angle / 2)
                {
                    float playerDistanceToEnemy = Vector3.Distance(transform.position, enemy.position);
                    if (!Physics.Raycast(transform.position, playerDirectionToEnemy, playerDistanceToEnemy, obstructionMask))
                    {
                        canSeeEnemy = true;
                    }
                    else
                    {
                        canSeeEnemy = false;
                        enemyRef = null;
                    }

                }
                else
                {
                    canSeeEnemy = false;
                    enemyRef = null;
                }
            }
        }
        else if (canSeeEnemy)
        {
            canSeeEnemy = false;
            enemyRef = null;
        }
    }
    private Transform GetClosestEnemy(Collider[] enemies)
    {
        Transform closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy.transform;
            }
        }

        return closestEnemy;
    }
}
