using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyFieldOfView))]
public class EnemyFieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        EnemyFieldOfView eFov = (EnemyFieldOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(eFov.transform.position, Vector3.up, Vector3.forward, 360, eFov.radius);

        Vector3 viewAngle01 = DirectionFromAngle(eFov.transform.eulerAngles.y, -eFov.angle / 2);
        Vector3 viewAngle02 = DirectionFromAngle(eFov.transform.eulerAngles.y, eFov.angle / 2);

        Handles.color = Color.yellow;
        Handles.DrawLine(eFov.transform.position, eFov.transform.position + viewAngle01 * eFov.radius);
        Handles.DrawLine(eFov.transform.position, eFov.transform.position + viewAngle02 * eFov.radius);

        if (eFov.canSeeEnemy)
        {
            Handles.color = Color.red;
            Handles.DrawLine(eFov.transform.position, eFov.enemyRef.transform.position);
        }
    }
    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
