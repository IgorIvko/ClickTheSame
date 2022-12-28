using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelsList : MonoBehaviour
{
    [SerializeField] private GameObject _levelsPanel;
    [SerializeField] private Button _levelsButton;
    [SerializeField] private Button _backButton;
    [SerializeField] private Button[] _levelList;
    [SerializeField] private EventSystem _eventSystem;
    private AsyncOperation _loadFirstLevel;
    private float _waitingTime = 0.5f;
    private float _currentTime = 0f;


    private void Awake()
    {
        _levelsButton.onClick.AddListener(OpenLevelsList);
        _backButton.onClick.AddListener(CloseLevelsList);

        foreach(Button item in _levelList)
        {
            item.onClick.AddListener(LoadLevel);
        }  
    }

    private void OpenLevelsList()
    {
        if (GameData.GameState == GameState.Play)
        {
            Time.timeScale = 0;
            GameData.GameState = GameState.Pause;
            _levelsPanel.SetActive(true);
        }
    }

    private void CloseLevelsList()
    {
        Time.timeScale = 1;
        GameData.GameState = GameState.Play;
        _levelsPanel.SetActive(false);
    }

    private void StartLoadingScene(string sceneName)
    {
        _loadFirstLevel = SceneManager.LoadSceneAsync(sceneName);
        _loadFirstLevel.allowSceneActivation = false;
    }

    private void Update()
    {
        if (_loadFirstLevel != null && _loadFirstLevel.progress >= 0.9f)
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= _waitingTime)
            {
                _loadFirstLevel.allowSceneActivation = true;
            }
        }
    }

    private void LoadLevel()
    {
        gameObject.GetComponent<LoadingWindow>().ShowLoadingWindow();
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive); //Loading

        GameData.GameState = GameState.Play;
        Time.timeScale = 1;
        SaveSettings();
        GameObject lastPressedButton = _eventSystem.currentSelectedGameObject;        
        StartLoadingScene(lastPressedButton.GetComponent<TextMesh>().text);
    }

    public void SaveSettings()
    {
        GameData.BackGroundMusicLevel = gameObject.GetComponent<Settings>().BackgroundMusic.volume;
        //GameData.GameplaySoundsLevel = gameObject.GetComponent<PlayDestroySound>().Sound.volume;
    }

}
