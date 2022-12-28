using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour
{
    public UnityAction<List<GameObject>> Destroy3;
    public UnityAction PlayTouchSound;
    public UnityAction PlayDestroySound;
    public UnityAction LevelComplete;
    public UnityAction GameOver;
    public UnityAction<bool> PauseBackgroundMusic;
    public UnityAction<int> AddScore;
    public UnityAction<int> PlayComboEffect;

}
