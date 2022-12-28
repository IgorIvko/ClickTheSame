using UnityEngine;

public class LoadingWindow : MonoBehaviour
{
    [SerializeField] private GameObject _loadingWindow;

    public void ShowLoadingWindow()
    {
        _loadingWindow.SetActive(true);
    }
}
