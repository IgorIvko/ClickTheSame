using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void Start()
    {
        _button.onClick.AddListener(QuitApp);
    }

    private void QuitApp()
    {
        if (GameData.GameState == GameState.Play)
        {
            Application.Quit();    
        }
    }

}
