using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pause;


    public void MainMeny()
    {
        SceneManager.LoadScene(0);
    }


    public void Resume()
    {
        Cursor.visible = true;

        GetComponent<Cart>().enabled = true;

        pause.SetActive(false);

        Time.timeScale = 1;

    }
}
