using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public enum Scene
    {
        MainMenu,
        Gameplay
    }
    private void Awake()
    {
        Time.timeScale = 1;
    }

    public void StartGame()
    {
        PackageEventHandler.ResetStaticData();
        Loader.Load(Loader.Scene.Gameplay);
        // SceneManager.LoadScene(Scene.Gameplay.ToString());
    }

    public void RestartGame()
    {
        GameOverHandler.Instance.Hide();
        PackageEventHandler.ResetStaticData();
        Loader.Load(Loader.Scene.Gameplay);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
