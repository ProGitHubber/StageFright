using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cam;
    public Transform cameraRef;

    public Vector3 camOffset;
    public Transform cameraTarget;

    public Vector2 minPosition;
    public Vector2 maxPosition;

    public float camMoveSpeed;
    [Range(0,1)]
    public float mouseDeadZone;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = cameraRef.transform.position;
        if (Input.GetKey(KeyCode.W)) //|| Input.mousePosition.y >= Screen.height - (Screen.height * mouseDeadZone))
        {
            pos.z += camMoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S)) //|| Input.mousePosition.y <= (Screen.height * mouseDeadZone))
        {
            pos.z -= camMoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A)) //|| Input.mousePosition.x >= (Screen.width * mouseDeadZone))
        {
            pos.x -= camMoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)) //|| Input.mousePosition.x <= Screen.width - (Screen.width * mouseDeadZone))
        {
            pos.x += camMoveSpeed * Time.deltaTime;
        }
        cameraRef.position = pos;
        Vector3 target = cameraRef.transform.position + camOffset;
        cam.transform.position = Vector3.Lerp(transform.position, target, 5 * Time.deltaTime);
        if (cameraTarget)
        {
            cam.LookAt(cameraTarget);
        }
    }
}
