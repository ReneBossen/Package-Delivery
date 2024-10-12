using TMPro;
using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
    public static GameOverHandler Instance { get; private set; }
    [SerializeField] private GameObject gameOverWindow;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private void Awake()
    {
        if (Instance != null) Debug.LogError("More than one GameOverHandler");
        Instance = this;
    }

    public void Show() => gameOverWindow.SetActive(true);
    public void Hide() => gameOverWindow.SetActive(false);
    public void SetHighScore()
    {
        highScoreText.text = Score.Instance.GetScore().ToString();
    }
}
