using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 2;
    public float speed = 3;
    public Transform target;
    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, 10 * Time.deltaTime);
        }
        else
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    void MoveToNearestTarget()
    {

        //findclosestone

        //setclosestoneastarget
    }
    private void OnCollisionEnter(Collision collision)
    {
        //checkforenemy

        //deal damage

        gameObject.SetActive(false);
    }
}
