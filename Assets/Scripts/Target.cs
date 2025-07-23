using UnityEngine;

public class Target : MonoBehaviour
{
    public float speed = 2f;             // Base movement speed
    public float frequency = 2f;         // Frequency of the oscillation
    public float amplitude = 0.5f;       // Amplitude of the oscillation

    private Vector3 moveDirection;       // Random direction for straight movement
    private Vector3 oscillationAxis;     // Perpendicular axis to oscillate on
    private Vector3 startPosition;
    private float time;
    public float value = 10.0f;

    void Start()
    {
        // Random base direction on XZ plane (can change to any axis)
        //moveDirection = Random.onUnitSphere;
        ////moveDirection.y = 0f;
        //moveDirection.Normalize();

        //// Choose a perpendicular axis to moveDirection for oscillation
        //oscillationAxis = Vector3.Cross(moveDirection, Vector3.up).normalized;

        //startPosition = transform.position;
        moveDirection = new Vector3(Random.Range(-value, value),Random.Range(-value, value),Random.Range(-value, value));
    }

    void Update()
    {
        //time += Time.deltaTime;

        // Base linear movement
        //Vector3 baseMove = moveDirection * speed * time;

        // Oscillating movement using sine wave
        //Vector3 oscillation = oscillationAxis * Mathf.Sin(time * frequency) * amplitude;
        //var oscillation = new Vector3(Mathf.Cos(Time.time * -speed) * amplitude, Mathf.Sin(Time.time * speed) * amplitude);

        // Final position
        //transform.position = startPosition + baseMove + oscillation;
        //transform.position =  oscillation;
        if (Vector3.Distance(transform.position, moveDirection) < 0.1f) 
        {
            moveDirection = new Vector3(Random.Range(-value, value), Random.Range(-value, value), Random.Range(-value, value));
        }
        transform.position = Vector3.MoveTowards(transform.position, moveDirection, speed * Time.deltaTime);

    }
}
