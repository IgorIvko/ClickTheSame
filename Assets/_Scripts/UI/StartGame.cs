using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Button _startGame;
    private AsyncOperation _loadFirstLevel;
    private float _waitingTime = 0.5f;
    private float _currentTime = 0f;

    private void Awake()
    {
        _startGame.onClick.AddListener(StartGameButton);        
    }

    private void StartLoadingScene()
    {
        _loadFirstLevel = SceneManager.LoadSceneAsync(GameData.FirstLevelIndex);
        _loadFirstLevel.allowSceneActivation = false;
    }

    private void Update()
    {
        if(_loadFirstLevel != null && _loadFirstLevel.progress >= 0.9f)
        {
            _currentTime += Time.deltaTime;
            if(_currentTime >= _waitingTime)
            {
                _loadFirstLevel.allowSceneActivation = true;
            }
        }
    }

    private void StartGameButton()
    {    
        if(GameData.GameState == GameState.Play)
        {
            gameObject.GetComponent<LoadingWindow>().ShowLoadingWindow();
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive); //Loading            

            if (gameObject.GetComponent<Settings>())
            {
                GameData.BackGroundMusicLevel = gameObject.GetComponent<Settings>().MusicScrollbar.value;
                GameData.GameplaySoundsLevel = gameObject.GetComponent<Settings>().GameplayScrollbar.value;
            }

            StartLoadingScene();                 
        }
    }

}
