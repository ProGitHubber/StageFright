using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 2;
    public float deathTime = 1;
    public float speed = 3;
    public Transform target;
    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject, deathTime);
            speed = 0;
        }
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
    private void OnTriggerEnter(Collider other)
    {
        //checkforenemy
        EnemyAI e = other.GetComponentInParent<EnemyAI>();

        if (e)
        {
            e.ReturnHome();
            gameObject.SetActive(false);
        }
        //deal damage
    }
}
