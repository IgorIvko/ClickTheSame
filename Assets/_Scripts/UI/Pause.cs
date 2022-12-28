using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _pauseWindows;
    private int _scale = 1;

    private void Start()
    {
        _button.onClick.AddListener(MakePause);
    }

    private void MakePause()
    {
        if (GameData.GameState == GameState.Play || _pauseWindows.activeSelf == true)
        {
            if (_scale == 1)
            {
                _scale = 0;
                Time.timeScale = _scale;
                GameData.GameState = GameState.Pause;
                //GameStateMenu.CurrentGameState = GameState.Pause;
                Manager.Events.PauseBackgroundMusic?.Invoke(false);
                _pauseWindows.SetActive(true);
            }
            else if (_scale == 0)
            {
                _scale = 1;
                Time.timeScale = _scale;
                GameData.GameState = GameState.Play;
                //GameStateMenu.CurrentGameState = GameState.Play;
                Manager.Events.PauseBackgroundMusic?.Invoke(true);
                _pauseWindows.SetActive(false);
            }
        }
    }
}
