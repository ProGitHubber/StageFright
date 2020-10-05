using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public AudioSource[] oneShotSounds;

    public void PlayOneShot()
    {
        oneShotSounds[SoundToPlay()].Play();
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
}
