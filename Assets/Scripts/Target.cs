using MindWave;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float speed = 5f;             // Base movement speed
    private Vector3 moveDirection;       // Random direction for straight movement
    private Vector3 direction;
    public float distance = 10f;

    void Start()
    {
        moveDirection = NewCoordinate();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, moveDirection) < 0.1f) 
        {
            moveDirection = NewCoordinate();
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
