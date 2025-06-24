
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{

    [SerializeField]
    AudioClip[] jumpSounds, hurtSounds;
    [SerializeField]
    AudioSource JumpAudioSource, HurtAudioSource;
    public void PlayJumpSound()
    {
        int choice = Random.Range(0, hurtSounds.Length);
        if(HurtAudioSource.isPlaying == false)
        {
            HurtAudioSource.clip = hurtSounds[choice];
            HurtAudioSource.pitch = Random.Range(0.9f, 1.1f);
            HurtAudioSource.volume = Random.Range(0.75f, 0.85f);
            HurtAudioSource.Play();
        }

        
    }

    public void PlayHurtSound()
    {
        int choice = Random.Range(0, jumpSounds.Length);
        if(HurtAudioSource.isPlaying == false)
        {
            JumpAudioSource.clip = jumpSounds[choice];
            JumpAudioSource.pitch = Random.Range(0.9f, 1.1f);
            JumpAudioSource.volume = Random.Range(0.75f, 0.85f);
            JumpAudioSource.Play();
        }
    }

}
