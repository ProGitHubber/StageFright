using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandMember : MonoBehaviour
{
    public int layer;
    public bool controlled;
    Rigidbody rb;
    Sequencer s;

    Vector3 direction;

    public float stepDistance;
    public Instrument instrument;

    public Sprite portrait;
    public GameObject selectionCircle;
    Transform target;
    public Transform directionIndicator;

    private void Start()
    {
        directionIndicator.parent = null;
        target = new GameObject().transform;
        target.position = transform.position;
        instrument = GetComponentInChildren<Instrument>();
        rb = GetComponent<Rigidbody>();
        s = FindObjectOfType<Sequencer>();
        s.onNewNote.AddListener(Move);
    }

    void Move()
    {

        if (s.output[layer])
        {
            instrument.LightAttack();
            target.position = selectionCircle.transform.position;
            direction = Vector3.zero;
        }
    }

    private void Update()
    {

        //if (controlled)
        //{
        //    if (Input.GetKey("w"))
        //    {
        //        direction.z = -1;
        //    }
        //    else if (Input.GetKey("s"))
        //    {
        //        direction.z = 1;
        //    }

        //    if (Input.GetKey("a"))
        //    {
        //        direction.x = 1;
        //    }
        //    else if (Input.GetKey("d"))
        //    {
        //        direction.x = -1;
        //    }
        //}
        float y = selectionCircle.transform.position.y;
        selectionCircle.transform.position = target.position + direction * stepDistance;
        selectionCircle.transform.position = new Vector3(selectionCircle.transform.position.x, y, selectionCircle.transform.position.z);
        rb.MovePosition(Vector3.Lerp(transform.position, target.position, 10 * Time.deltaTime));

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation((directionIndicator.position - transform.position).normalized), 10 * Time.deltaTime);
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);

    }
}
