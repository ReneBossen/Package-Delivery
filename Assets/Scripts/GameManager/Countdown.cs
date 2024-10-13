using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float timer = 120;
    private readonly int timeBonus = 7;

    void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        timer -= Time.deltaTime;
        timerText.text = ((int)timer).ToString();

        if (timer <= 0)
        {
            GameOver();
        }
    }

    public void AddTime()
    {
        timer += timeBonus;
    }

    private void GameOver()
    {
        GameOverHandler.Instance.Show();
        GameOverHandler.Instance.SetHighScore();
        Time.timeScale = 0;
    }
}