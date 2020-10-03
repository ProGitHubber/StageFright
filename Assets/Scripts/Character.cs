using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public Sprite portrait;
    public Transform target;
    public float moveSpeed, stopDis;
    bool moving;
    Vector3 previousPos;
    public bool playerCharacter;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target && Vector3.Distance(transform.position, target.position) > stopDis)
        {
            //move towards target
            transform.position += (target.position - transform.position).normalized * moveSpeed * Time.deltaTime;
        }

        if (transform.position != previousPos)
        {
            moving = true;
            anim.SetBool("Moving", true);
            previousPos = transform.position;
        }
        else
        {
            moving = false;
            anim.SetBool("Moving", false);
        }
    }
}
