using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private Button _startGame;
    private AsyncOperation _loadFirstLevel;
    private float _waitingTime = 0.5f;
    private float _currentTime = 0f;

    private void Awake()
    {
        _startGame.onClick.AddListener(NextLevelButton);
    }

    private void StartLoadingScene(int indexScene)
    {
        _loadFirstLevel = SceneManager.LoadSceneAsync(indexScene);
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

    private void NextLevelButton()
    {
        gameObject.GetComponent<LoadingWindow>().ShowLoadingWindow();
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive); //Loading

        if (GameData.CurrentLevel < GameData.LevelsCount)
        {
            StartLoadingScene(GameData.FirstLevelIndex + GameData.CurrentLevel);               
        }
        else
        {
            StartLoadingScene(GameData.FirstLevelIndex);
        }
        
    }
}
