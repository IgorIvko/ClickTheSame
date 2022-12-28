using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _backButton;
    [Space(20)]
    [SerializeField] private GameObject _settingsPanel;
    public AudioSource BackgroundMusic;
    public AudioSource[] GameplaySounds;
    [Header("Scrollbars")]
    public Scrollbar MusicScrollbar;
    public Scrollbar GameplayScrollbar;

    private void Awake()
    {
        _settingsButton.onClick.AddListener(OpenSettings);
        _backButton.onClick.AddListener(CloseSettings);        
        MusicScrollbar.value = GameData.BackGroundMusicLevel;
        GameplayScrollbar.value = GameData.GameplaySoundsLevel;
        ////
        //Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
    }

    private void OpenSettings()
    {
        if (GameData.GameState == GameState.Play)
        {
            Time.timeScale = 0;
            GameData.GameState = GameState.Pause;
            _settingsPanel.SetActive(true);
        }
    }

    private void CloseSettings()
    {
        Time.timeScale = 1;
        GameData.GameState = GameState.Play;
        _settingsPanel.SetActive(false);
    }
}
