using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyWhiskExitDoor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene("FlyWhiskWin");
        }
    }
}
