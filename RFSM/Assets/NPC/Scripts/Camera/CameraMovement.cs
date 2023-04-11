using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    //CameraTarget
    public Transform target;
    public Vector3 offset;
    public float pitch = 2f;
    private float zoomNow = 10f;

    //Zoom
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;

    //CameraFollowChara
    public float ySpeed = 100f;
    private float yInput = 0f;
    


    void Update(){
        zoomNow -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        zoomNow = Mathf.Clamp(zoomNow, minZoom, maxZoom);

        yInput -= Input.GetAxis("Horizontal") * ySpeed * Time.deltaTime; 
    }

    void LateUpdate()
    {
        transform.position = target.position - offset * zoomNow;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, yInput);
    }
}
