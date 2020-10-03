using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Intrument : MonoBehaviour
{
    Sequencer s;
    Animator anim;
    public int layer;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        s = FindObjectOfType<Sequencer>();
        s.onNewNote.AddListener(PlayNote);
    }

    void PlayNote()
    {
        if (s.output[layer])
        {
            //do stuff
            anim.SetTrigger("Attack");
            Debug.Log(gameObject.name + " played a note");
        }
    }
}
