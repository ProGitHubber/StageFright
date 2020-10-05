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

    public CharacterMover cm;

    public Transform defaultPos;

    public int numberOfVariations;
    public Animator cameraAnim;
    int previousVid;

    // Update is called once per frame
    void Update()
    {
       Vector3 offset = camOffset;
        if (cm.character)
        {
            cameraAnim.enabled = false;
            cameraTarget = cm.character.transform;
            cam.rotation = Quaternion.Lerp(cam.transform.rotation, Quaternion.LookRotation((cameraTarget.position - cam.transform.position).normalized), camMoveSpeed * Time.deltaTime);


            Vector3 target = cameraTarget.transform.position + offset;
            cam.transform.position = Vector3.Lerp(cam.transform.position, target, camMoveSpeed * Time.deltaTime);
        }
    }

    public void SetRandomCameraAnim()
    {       
        cameraAnim.SetInteger("CamInt", Random.Range(0, numberOfVariations));
    }
    int GetNonRepeatingRandomNumber()
    {
        int i = Random.Range(0, numberOfVariations);
        if (i != previousVid)
        {
            previousVid = i;
            return i;
        }
        else
        {
            return GetNonRepeatingRandomNumber();
        }
    }
}
