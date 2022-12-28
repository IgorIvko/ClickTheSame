using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;

    private void Awake()
    {
        _score.text = "Score: " + GameData.Score;
    }
}
