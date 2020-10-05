using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float NumberOfMoves = 2;
    public float deathTime = 1;
    public float moveDistance;
    public Transform target;

    public int layer;

    Sequencer s;

    private void Start()
    {
        target = new GameObject().transform;
        target.position = transform.position;
        s = FindObjectOfType<Sequencer>();
        s.onNewNote.AddListener(Move);
    }

    void Move()
    {
        target.position += transform.forward * moveDistance;
        NumberOfMoves--;
        if (NumberOfMoves <= 0)
        {
            moveDistance = 0;
            Destroy(gameObject, deathTime);
        }
    }
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, 10 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Zombie z = other.GetComponentInParent<Zombie>();
        if (z)
        {
            z.Hit(this);
            Destroy(gameObject);
        }
    }
}
