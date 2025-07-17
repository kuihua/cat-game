using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource BGM;

    //change BGM music by stopping the previous one and changing it to the next one
    public void ChangeBGM(AudioClip music)
    {
        //if the same music is playing, prevents the bgm from starting from the beginning
        if(BGM.clip.name == music.name)
            return;

        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
    }
}
