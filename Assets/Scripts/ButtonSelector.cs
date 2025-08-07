using Unity.VisualScripting;
using UnityEngine;

public class ButtonSelector : MonoBehaviour
{
    public Canvas canvas;
    public new GameObject gameObject;
    [HideInInspector] public float reqFocus;
    private GameManager manager;

    private void Start()
    {
        manager = FindFirstObjectByType<GameManager>();
    }
    private void Update()
    {
        if (manager.count == 1)
        {
            canvas.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void EasyLevel()
    {
        reqFocus = 60.0f;
        RepeatedTask();
    }
    public void MediumLevel()
    {
        reqFocus = 70.0f;
        RepeatedTask();
    }
    public void HardLevel()
    {
        reqFocus = 80.0f;
        RepeatedTask();
    }
    public void ExpertLevel()
    {
        reqFocus = 90.0f;
        RepeatedTask();
    }

    private void RepeatedTask()
    {
        manager.count = 2;
        canvas.gameObject.SetActive(false);
        gameObject.SetActive(true);
    }
}
