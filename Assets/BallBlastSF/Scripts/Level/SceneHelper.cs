using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHelper : MonoBehaviour
{
    [SerializeField] private LevelProgress LevelProgress;


    public void RestatrLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadLevel(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
        LevelProgress.Save();

    }

    public void Quit()
    {
        Application.Quit();
    }
}
