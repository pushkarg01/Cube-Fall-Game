using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static SoundManagerScript instance;

    [SerializeField] private AudioSource soundFX;

    [SerializeField] private AudioClip landClip, deathClip, iceBreakClip, gameEndClip;

    private void Awake()
    {
        if(instance == null) instance = this;
    }

    public void LandSound()
    {
        soundFX.clip = landClip;
        soundFX.Play();
    }

    public void IceBreakSound()
    {
        soundFX.clip = iceBreakClip;
        soundFX.Play();
    }

    public void DeathSound()
    {
        soundFX.clip = deathClip;
        soundFX.Play();
    }

    public void GameOverSound()
    {
        soundFX.clip = gameEndClip;
        soundFX.Play();
    }
}
