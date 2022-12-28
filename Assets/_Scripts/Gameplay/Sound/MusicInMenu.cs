using UnityEngine;

public class MusicInMenu : MonoBehaviour
{
    public AudioSource Music;

    private void Awake()
    {
        Music.volume = GameData.BackGroundMusicLevel;
    }
}
