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
    public Transform[] attackOrigins;
    public GameObject heavyAttack;
    public float heavyAttackDelay = 0.25f;

    public KeyCode key = KeyCode.Alpha1;

    Character c;
    // Start is called before the first frame update
    void Start()
    {
        c = GetComponentInParent<Character>();
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

        if (Input.GetKeyDown(key))
        {
            //s.signalsRecieved[layer] = "1";
            anim.SetTrigger("Attack");
            Invoke("HeavyAttack", heavyAttackDelay);
        }
    }

    void PlayNote()
    {
        if (s.output[layer])
        {
            //do stuff

                //anim.SetTrigger("Attack");
                //Invoke("HeavyAttack", heavyAttackDelay);
        }
    }

    public void LightAttack()
    {
        if (cooldownTimer <= 0)
        {
            onLightAttack.Invoke();
            if (bulletPrefab)
            {
                foreach (Transform attackOrigin in attackOrigins)
                {
                    if (attackOrigin.gameObject.activeInHierarchy)
                        Instantiate(bulletPrefab.gameObject, attackOrigin.position, attackOrigin.rotation);
                }
            }
            cooldownTimer = lightAttackCooldown;
        }
    }

    void HeavyAttack()
    {
        onHeavyAttack.Invoke();
        if (heavyAttack)
            heavyAttack.SetActive(true);
        //onLightAttack.Invoke();
        //if (bulletPrefab)
        //{
        //    foreach (Transform attackOrigin in attackOrigins)
        //    {
        //        if (attackOrigin.gameObject.activeInHierarchy)
        //            Instantiate(bulletPrefab.gameObject, attackOrigin.position, attackOrigin.rotation);
        //    }
        //}
        //cooldownTimer = lightAttackCooldown;
    }
    public void Unplug()
    {
        s.onNewNote.RemoveAllListeners();
        enabled = false;
    }
}
