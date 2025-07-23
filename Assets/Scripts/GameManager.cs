using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public void RocketLauncher()
    {
        SceneManager.LoadScene("RocketLauncher");
    }

    public void MainPage()
    {
        SceneManager.LoadScene("Main");
    }
}
