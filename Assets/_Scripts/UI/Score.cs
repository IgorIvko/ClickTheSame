using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;

    private void Start()
    {
        Manager.Events.AddScore += OnAddScore;        
    }

    private void OnAddScore(int score)
    {
        Manager.LevelData.CurrentScore += score;
        _score.text = "Score: " + Manager.LevelData.CurrentScore;
    }
}
