using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    private AsyncOperation _loadFirstLevel;
    private float _waitingTime = 0.5f;
    private float _currentTime = 0f;

    private void Start()
    {
        _button.onClick.AddListener(LoadLobbyScene);
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

    private void LoadLobbyScene()
    {
        if (GameData.GameState == GameState.Play)
        {
            gameObject.GetComponent<LoadingWindow>().ShowLoadingWindow();
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive); //Loading

            StartLoadingScene(0); //Lobby
            // SceneManager.LoadScene(0); 
        }
    }
}
