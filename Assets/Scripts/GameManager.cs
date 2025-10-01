using UnityEngine;
using UnityEngine.UI; // If you use TextMeshPro, see note below.

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("UI")]
    [SerializeField] private Text scoreText; // ✅ assign in Inspector

    public int Score { get; private set; } = 0;   // ✅ public getter, private setter

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        // Optional: DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        UpdateScoreUI(); // fixes 'scoreText' undefined usage at Start
    }

    public void IncrementScore(int amount = 1)
    {
        Score += amount;
        if (Score < 0) Score = 0;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {Score}";
        }
        // If null, we just skip; avoids null-ref during early loads.
    }

    // Optional: static helper if some code calls GameManager.IncrementScore(...)
    public static void AddScore(int amount = 1)
    {
        if (Instance != null) Instance.IncrementScore(amount);
    }
}