using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;

    [SerializeField] private AudioSource soundFXObject;

    // creating a singleton so only one exists on scene
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //spawn in game object
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        if(audioSource != null){
                //assign the audio clip
                audioSource.clip = audioClip;

                //assign volume
                audioSource.volume = volume;

                //play clip
                audioSource.Play();

                //get sound fx clip length
                float clipLength = audioSource.clip.length;

                //destroy the clip after finished playing
                Destroy(audioSource.gameObject, clipLength);
        }else{
            Debug.Log("no audio clip found in manager");
        }

    }

    public void PlayRandomSoundFXClip(AudioClip[] audioClip, Transform spawnTransform, float volume)
    {

        //assign random index
        int rand = Random.Range(0, audioClip.Length);

        //spawn in game object
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        if(audioSource != null){
                //assign the audio clip
                audioSource.clip = audioClip[rand];

                //assign volume
                audioSource.volume = volume;

                //play clip
                audioSource.Play();

                //get sound fx clip length
                float clipLength = audioSource.clip.length;

                //destroy the clip after finished playing
                Destroy(audioSource.gameObject, clipLength);
        }else{
            Debug.Log("no audio clip found in manager");
        }

    }

}
