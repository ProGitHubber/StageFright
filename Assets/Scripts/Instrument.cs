using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Instrument : MonoBehaviour
{
    Animator anim;
    public int layer;

    public UnityEvent onLightAttack;

    public Bullet bulletPrefab;
    public Transform[] attackOrigins;
    public GameObject heavyAttack;
    public float heavyAttackDelay = 0.25f;
    public AudioSource[] oneShotSounds;
    BandMember c;
    // Start is called before the first frame update
    void Start()
    {
        c = GetComponentInParent<BandMember>();
        layer = c.layer;
        anim = GetComponent<Animator>();
    }



    void Lattack()
    {
        onLightAttack.Invoke();

        if (bulletPrefab)
        {
            foreach (Transform attackOrigin in attackOrigins)
            {
                if (attackOrigin.gameObject.activeInHierarchy)
                {
                    Bullet b = Instantiate(bulletPrefab.gameObject, attackOrigin.position, attackOrigin.rotation).GetComponent<Bullet>();
                    b.layer = layer;
                }

            }
        }
    }

    int SoundToPlay()
    {
        int s = Random.Range(0, oneShotSounds.Length);
        if (!oneShotSounds[s].isPlaying)
        {
            return s;
        }
        else
        {
            return SoundToPlay();
        }
    }

    public void LightAttack()
    {
        //oneShotSounds[SoundToPlay()].Play();
        anim.SetTrigger("Attack");
        Invoke("Lattack", heavyAttackDelay);
    }

}
