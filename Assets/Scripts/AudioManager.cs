using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioNote
{
    public Sound[] layers;
    
}

public class AudioManager : MonoBehaviour
{
    public AudioNote[] audioNotes;
    public AudioSource[] lowLayers;
    Sequencer s;
    // Start is called before the first frame update
    void Start()
    {
        s = FindObjectOfType<Sequencer>();
        s.onNewNote.AddListener(PlaySound);
    }


    void PlaySound()
    {
        AudioNote an = audioNotes[s.currentNote];
        for (int i = s.layers - 1; i >= 0; i--)
        {
            if (s.output[i])
            {

                an.layers[i].PlayOneShot();
            }
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
