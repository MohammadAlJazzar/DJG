using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public Audio jump;
    public Audio score;
    public Audio lose;



    public static SoundManager Instance;

    private void Awake()
    {
        if(Instance== null)
        {
            Instance =this;
            DontDestroyOnLoad(gameObject);


        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(Audio audio)
    {
        audioSource.PlayOneShot(audio.clip, audio.volume);
    }
    [System.Serializable]
    public class Audio
    {
        public AudioClip clip;
        [Range(0,1)]
        public float volume;

    }
}
