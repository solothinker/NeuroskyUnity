using System.Collections;
using MindWave;
using Unity.Mathematics;
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
    private ButtonSelector buttonSelector;
    public GameObject explosion;
    private Collider Collider;
    private float TimeCounter = 0f;

    private GameManager manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        neuroskyGUIManager = FindAnyObjectByType<NeuroskyGUIManager>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        buttonSelector = FindAnyObjectByType<ButtonSelector>();
        Collider = GetComponent<Collider>();
        manager = FindFirstObjectByType<GameManager>();
    }
    private void Update()
    {
        if (manager.count == 1)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        TimeCounter += Time.deltaTime;
        // Managaing the Rocket speed
        if (TimeCounter >= 1f)
        {
            if (neuroskyGUIManager.meditationValue >= buttonSelector.reqFocus)
            {
                speed += 1;
                //speed = Mathf.Min(speed, 10);
            }
            else
            {
                speed -= 1;
                //speed = Mathf.Max(speed, 4);
            }
            speed = Mathf.Clamp(speed, 4, 10);
            TimeCounter = 0f;
        }

        Vector3 direction = (target.position - transform.position).normalized;
        Vector3 euler = Quaternion.LookRotation(direction).eulerAngles;
        
        Vector3 modifiedEuler = new Vector3(euler.x, 90f, euler.z);
        Quaternion targetRotation = Quaternion.Euler(euler);
        Quaternion newRotation = Quaternion.RotateTowards(rb.rotation, targetRotation, rotateSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(newRotation);
        rb.linearVelocity = transform.forward * speed;// * (float)neuroskyGUIManager.meditationValue / gameManager.reqFocus;
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
