using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Instrument : MonoBehaviour
{
    Sequencer s;
    Animator anim;
    public int layer;

    public float lightAttackCooldown;
    float cooldownTimer;
    public UnityEvent onLightAttack, onHeavyAttack;

    public Bullet bulletPrefab;
    public Transform attackOrigin;
    public GameObject heavyAttackPrefab;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        s = FindObjectOfType<Sequencer>();
        s.onNewNote.AddListener(PlayNote);
    }

    private void Update()
    {
        if (cooldownTimer >= 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    void PlayNote()
    {
        if (s.output[layer])
        {
            //do stuff
            anim.SetTrigger("Attack");
            HeavyAttack();
        }
    }

    public void LightAttack()
    {
        if (cooldownTimer <= 0)
        {
            onLightAttack.Invoke();
            Instantiate(bulletPrefab, attackOrigin.position, attackOrigin.rotation);
        }
    }

    void HeavyAttack()
    {
        onHeavyAttack.Invoke();
        Instantiate(heavyAttackPrefab, attackOrigin.position, attackOrigin.rotation);
    }
}
