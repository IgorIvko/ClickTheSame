using UnityEngine;

public class PlayTouchSound : MonoBehaviour
{
    public AudioSource Sound;

    private void Start()
    {
        Manager.Events.PlayTouchSound += PlaySound;        
    }

    private void PlaySound()
    {
        Sound.Play();
    }

    private void OnDisable()
    {
        Manager.Events.PlayTouchSound -= PlaySound;
    }
}
