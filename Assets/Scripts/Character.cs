using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public Sprite portrait;
    public Transform target;
    public float moveSpeed, stopDis;
    Vector3 previousPos;

    public bool grabbed;

    Animator anim;

    Rigidbody rb;

    public Instrument instrument;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target && Vector3.Distance(transform.position, target.position) > stopDis)
        {
            //move towards target
            rb.MovePosition(transform.position + (target.position - transform.position).normalized * moveSpeed * Time.deltaTime);
        }

        if (transform.position != previousPos)
        {
            anim.SetBool("Moving", true);
            previousPos = transform.position;
        }
        else
        {
            anim.SetBool("Moving", false);
        }
    }
}
