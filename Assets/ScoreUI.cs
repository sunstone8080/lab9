using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private TMP_Text scoreText;

    void OnEnable()  { scoreManager.OnScoreChanged += UpdateText; }
    void OnDisable() { scoreManager.OnScoreChanged -= UpdateText; }

    private void UpdateText(int score) => scoreText.text = $"Score: {score}";
}
