﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //public Transform cam;
    //public Transform cameraRef;

    //public Vector3 camOffset;
    //public Transform cameraTarget;

    //public Vector2 minPosition;
    //public Vector2 maxPosition;

    //public float camMoveSpeed;
    //[Range(0,1)]
    //public float mouseDeadZone;

    //public CharacterMover cm;

    //public Transform defaultPos;

    public int numberOfVariations;
    public Animator cameraAnim;
    int previousVid;

    // Update is called once per frame
    void Update()
    {
        //Vector3 offset = camOffset;
        //if (!cm.character)
        //{
        //    cameraRef = defaultPos;
        //    offset = Vector3.zero;
        //}
        //else
        //{
        //    cameraRef = cm.character.transform;
        //    cam.rotation = Quaternion.Lerp(cam.transform.rotation, Quaternion.LookRotation((cameraRef.position - cam.transform.position).normalized), camMoveSpeed * Time.deltaTime);
        //}
        //Vector3 pos = cameraRef.transform.position;
        //if (Input.GetKey(KeyCode.W)) //|| Input.mousePosition.y >= Screen.height - (Screen.height * mouseDeadZone))
        //{
        //    pos.z -= camMoveSpeed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.S)) //|| Input.mousePosition.y <= (Screen.height * mouseDeadZone))
        //{
        //    pos.z += camMoveSpeed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.A)) //|| Input.mousePosition.x >= (Screen.width * mouseDeadZone))
        //{
        //    pos.x += camMoveSpeed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.D)) //|| Input.mousePosition.x <= Screen.width - (Screen.width * mouseDeadZone))
        //{
        //    pos.x -= camMoveSpeed * Time.deltaTime;
        //}
        //cameraRef.position = pos;
        //Vector3 target = cameraRef.transform.position + offset;
        //cam.transform.position = Vector3.Lerp(cam.transform.position, target, camMoveSpeed * Time.deltaTime);

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
