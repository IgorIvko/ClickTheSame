using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartLevel : MonoBehaviour
{
    [SerializeField] private Button _button;
    private AsyncOperation _loadFirstLevel;
    private float _waitingTime = 0.5f;
    private float _currentTime = 0f;

    private void Start()
    {
        _button.onClick.AddListener(ReloadCurrentLevel);
    }

    private void StartLoadingScene()
    {
        _loadFirstLevel = SceneManager.LoadSceneAsync(GameData.FirstLevelIndex + GameData.CurrentLevel - 1);
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

    private void ReloadCurrentLevel()
    {
        if (GameData.GameState == GameState.Play)
        {
            gameObject.GetComponent<LoadingWindow>().ShowLoadingWindow();
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive); //Loading
            StartLoadingScene();
        }
    }
}
