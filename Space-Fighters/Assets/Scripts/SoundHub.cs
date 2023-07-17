using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHub : MonoBehaviour
{
    AudioSource[] sources;
    private void Awake()
    {
        sources = GetComponents<AudioSource>();
    }

    public void PlayPlayerShootSound()
    {
        sources[0].Play();
    }

    public void PlayEnemyShootSound()
    {
        sources[1].Play();
    }
    public void PlayExplosionSound()
    {
        sources[2].Play();
    }
    public void PlayScoreSound()
    {
        sources[3].Play();
    }
}
