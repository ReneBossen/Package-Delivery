using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        GameOverHandler.Instance.Hide();
        PackageEventHandler.ResetStaticData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
