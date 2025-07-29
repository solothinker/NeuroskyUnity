using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public float reqFocus;
    public Canvas canvas;
    private int count = 0;
    public new GameObject gameObject;
    public void RocketLauncher()
    {
        FindAnyObjectByType<AudioManager>().Play("ButtonClick");
        SceneManager.LoadScene("RocketLauncher");
    }

    public void MainPage()
    {
        if (count == 1) 
        {
            count -= 1;
            canvas.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene("Main");
        }
    }
    public void EasyLevel()
    {
        reqFocus = 60.0f;
        count += 1;
        canvas.gameObject.SetActive(false);
        gameObject.SetActive(true);
    }
    public void MediumLevel()
    {
        reqFocus = 70.0f;
        count += 1;
        canvas.gameObject.SetActive(false);
        gameObject.SetActive(true);
    }
    public void HardLevel()
    {
        reqFocus = 80.0f;
        count += 1;
        canvas.gameObject.SetActive(false);
        gameObject.SetActive(true);
    }
    public void ExpertLevel()
    {
        reqFocus = 90.0f;
        count += 1;
        canvas.gameObject.SetActive(false);
        gameObject.SetActive(true);
    }
}
