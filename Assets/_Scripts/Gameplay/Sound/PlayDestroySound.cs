using UnityEngine;

public class PlayDestroySound : MonoBehaviour
{
    public AudioSource Sound;

    private void Start()
    {
        Manager.Events.PlayDestroySound += PlaySound;
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

