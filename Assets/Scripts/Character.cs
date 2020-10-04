using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    public bool controlled;
    public bool mainCharacter;
    public Sprite portrait;
    public Transform target;
    public float moveSpeed, stopDis;
    Vector3 previousPos;
    public GameObject selectionCircle;
    public Character grabbedBy;

    Animator anim;

    Rigidbody rb;

    public Instrument instrument;

    public bool targetReached;
    public UnityEvent onTargetReached = new UnityEvent();


    //[Header("RecordingSettings")]
    
    // Start is called before the first frame update
    void Start()
    {
        target = new GameObject().transform;
        target.position = transform.position;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbedBy)
        {
            if (instrument.enabled)
            {
                //instrument.Unplug();
            }
            target = grabbedBy.transform;
            moveSpeed = grabbedBy.moveSpeed;
            anim.SetBool("Carried", true);
            if (!grabbedBy.gameObject.activeInHierarchy)
            {
                gameObject.SetActive(false);
            }
        }
        if (target)
        {
            rb.MovePosition(Vector3.Lerp(transform.position, target.position, moveSpeed * Time.deltaTime));
            if (Vector3.Distance(transform.position, target.position) > stopDis)
            {
                targetReached = false;
                //move towards target
                //rb.MovePosition(transform.position + (target.position - transform.position).normalized * moveSpeed * Time.deltaTime);
                //rb.MovePosition(Vector3.Lerp(transform.position, target.position, moveSpeed * Time.deltaTime));
                
            }
            else
            {
                if (!targetReached)
                {
                    targetReached = true;
                    onTargetReached.Invoke();
                }
            }
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
