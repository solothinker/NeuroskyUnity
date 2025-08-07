using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    
    [HideInInspector]public int count = 0;
    
    public void RocketLauncher()
    {
        FindAnyObjectByType<AudioManager>().Play("ButtonClick");
        SceneManager.LoadScene("RocketLauncher");
    }

    public void MainPage()
    {
        if (count == 1)
        {
            SceneManager.LoadScene("Main");
        }
        count--;
    }
   
}
