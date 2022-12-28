using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource Music;    

    private void Start()
    {
        Manager.Events.PauseBackgroundMusic += PauseMusic;
    }

    private void PauseMusic(bool IsMusicPaused)
    {
        if (!IsMusicPaused) Music.Pause();
        else Music.Play();
    }
}
