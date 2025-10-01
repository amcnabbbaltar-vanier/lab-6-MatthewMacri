using UnityEngine;
using TMPro;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreText;

    private void OnEnable()
    {
        int finalScore = (GameManager.Instance != null) ? GameManager.Instance.Score : 0;
        if (finalScoreText != null)
            finalScoreText.text = $"Final Score: {finalScore}";
    }
}