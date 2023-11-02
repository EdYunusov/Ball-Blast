using UnityEngine;

public class Wait_Pause : MonoBehaviour
{
    [SerializeField] private GameObject pause;

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Time.timeScale = 0;

            GetComponent<Cart>().enabled = false;

            pause.SetActive(true);
        }
    }
}
