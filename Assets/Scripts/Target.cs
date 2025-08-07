using MindWave;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float speed = 5f;             // Base movement speed
    private Vector3 moveDirection;       // Random direction for straight movement
    private Vector3 direction;
    public float distance = 10f;
    private GameManager manager;
    private NeuroskyGUIManager neuroskyGUIManager;
    private ButtonSelector buttonSelector;
    private float TimeCounter = 0f;

    void Start()
    {
        moveDirection = NewCoordinate();
        manager = FindFirstObjectByType<GameManager>();
        neuroskyGUIManager = FindAnyObjectByType<NeuroskyGUIManager>();
        buttonSelector = FindAnyObjectByType<ButtonSelector>();
    }

    void FixedUpdate()
    {
        if (manager.count == 1)
        {
            Destroy(gameObject);
        }

        if (Vector3.Distance(transform.position, moveDirection) < 0.1f) 
        {
            moveDirection = NewCoordinate();
        }

        TimeCounter += Time.deltaTime;
        // Managaing the Rocket speed
        if (TimeCounter >= 1f)
        {
            if (neuroskyGUIManager.meditationValue >= buttonSelector.reqFocus)
            {
                speed -= 1;
                //speed = Mathf.Max(speed, 4);
            }
            else
            {
                speed += 1;
                //speed = Mathf.Min(speed, 10);
            }
            speed = Mathf.Clamp(speed, 4, 10);
            TimeCounter = 0f;
        }
        transform.position = Vector3.MoveTowards(transform.position, moveDirection, speed *  Time.deltaTime);
    }
    private Vector3 NewCoordinate()
    {
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(0f, 1f)).normalized;
        direction = transform.position + Random.Range(0, distance) * direction;

        return direction;
    }
    private void OnTriggerEnter()
    {
        Destroy(gameObject);
    }
}
