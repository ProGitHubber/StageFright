using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Zombie : MonoBehaviour
{
    public UnityEvent onCure = new UnityEvent();
    public int layer;
    public Color[] layerColor = new Color[4];
    public Color curedColor = Color.clear;
    public Renderer spriteImage;

    Sequencer s;
    Rigidbody rb;

    public Transform target;

    public float moveDistance;

    public bool cured;
    public Material curedMaterial;
    public Renderer zombieHead;

    public Animator anim;

    Transform moveTarget;

    bool hit;
    // Start is called before the first frame update
    void Start()
    {
        moveTarget = new GameObject().transform;
        moveTarget.position = transform.position;
        rb = GetComponent<Rigidbody>();
        s = FindObjectOfType<Sequencer>();
        s.onNewNote.AddListener(Step);

        spriteImage.material.color = layerColor[layer];
    }


    void Step()
    {
        hit = false;
        if (s.output[layer])
        {
            if (!cured)
            {
                if (anim)
                anim.SetTrigger("Walk");
            }
            float disToTarget = Vector3.Distance(transform.position, target.position);
            if (disToTarget < moveDistance)
            {
                s.playing = false;
                s.GameOver();
            }
            moveTarget.position = (transform.position + (target.position - transform.position).normalized * ((disToTarget<moveDistance) ? disToTarget : moveDistance));
        }
    }

    private void Update()
    {
        rb.MovePosition(Vector3.Lerp(transform.position, moveTarget.position, 10 * Time.deltaTime));
    }

    public void Hit(Bullet hitBy)
    {
        if (hitBy.layer == layer)
        {
            Cure();
        }
        else
        {
            if (anim && !hit)
            {
                anim.SetTrigger("Hit");
                hit = true;
            }
        }
    }
    public void DestroySelf()
    {
        FindObjectOfType<ZombieSpawner>().DecreaseCurrentlySpawned();
        Destroy(gameObject, 0.01f);
    }

    void Cure()
    {
        if (!cured)
        {
            spriteImage.material.color = curedColor;
            if (anim)
            anim.SetTrigger("Cured");
            zombieHead.material = curedMaterial;
            moveDistance = -moveDistance;
            cured = true;
        }
    }
}
