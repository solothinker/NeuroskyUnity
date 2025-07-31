using System.Collections;
using MindWave;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.DebugUI;
[RequireComponent (typeof(Rigidbody))]
public class HomingMissile : MonoBehaviour
{
    private Transform target;
    public float speed = 5.0f;
    public float rotateSpeed = 200.0f;
    private Rigidbody rb;
    private NeuroskyGUIManager neuroskyGUIManager;
    private GameManager gameManager;
    public GameObject explosion;
    private Collider Collider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        neuroskyGUIManager = FindAnyObjectByType<NeuroskyGUIManager>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        gameManager = FindAnyObjectByType<GameManager>();
        Collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        Vector3 direction = (target.position - transform.position).normalized;
        Vector3 euler = Quaternion.LookRotation(direction).eulerAngles;
        
        Vector3 modifiedEuler = new Vector3(euler.x, 90f, euler.z);
        Quaternion targetRotation = Quaternion.Euler(euler);
        Quaternion newRotation = Quaternion.RotateTowards(rb.rotation, targetRotation, rotateSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(newRotation);
        rb.linearVelocity = transform.forward * speed * (float)neuroskyGUIManager.meditationValue / gameManager.reqFocus;
        // Disabling the collider value if it is lower then the required focuse value
        //if (neuroskyGUIManager.meditationValue >= gameManager.reqFocus)
        //{
        //    Collider.enabled = true;
        //}
        //else
        //{
        //    Collider.enabled = false;
        //}

        
    }

    private void OnTriggerEnter()
    {

        GameObject explosionInstance = Instantiate(explosion,transform.position,transform.rotation);
        FindAnyObjectByType<AudioManager>().Play("BombExplosion");

        Destroy(gameObject);
        Destroy(explosionInstance, 1f);
    }
}
