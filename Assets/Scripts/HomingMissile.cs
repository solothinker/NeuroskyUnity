using UnityEngine;
using MindWave;
[RequireComponent (typeof(Rigidbody))]
public class HomingMissile : MonoBehaviour
{
    private Transform target;
    public float speed = 5.0f;
    public float rotateSpeed = 200.0f;
    private Rigidbody rb;
    private NeuroskyGUIManager neuroskyGUIManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        neuroskyGUIManager = FindAnyObjectByType<NeuroskyGUIManager>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Vector3 euler = Quaternion.LookRotation(direction).eulerAngles;
        //Debug.Log(euler.ToString());
        Vector3 modifiedEuler = new Vector3(euler.x, 90f, euler.z);
        Quaternion targetRotation = Quaternion.Euler(euler);
        Quaternion newRotation = Quaternion.RotateTowards(rb.rotation, targetRotation, rotateSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(newRotation);
        rb.linearVelocity = transform.forward * speed * (float)neuroskyGUIManager.meditationValue / 30.0f ;

    }
}
