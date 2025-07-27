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
    private int ReqMeditationValue = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        neuroskyGUIManager = FindAnyObjectByType<NeuroskyGUIManager>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        gameManager = FindAnyObjectByType<GameManager>();
        //FindAnyObjectByType<AudioManager>().Play("BurningRocket");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.reqFocus == 30.0f) { ReqMeditationValue = 60; }
        else if (gameManager.reqFocus == 35.0f) { ReqMeditationValue = 70; }
        else if (gameManager.reqFocus == 40.0f) { ReqMeditationValue = 80; }
        else if (gameManager.reqFocus == 45.0f) { ReqMeditationValue = 90; }

        if (ReqMeditationValue < neuroskyGUIManager.meditationValue && Vector3.Distance(target.position,transform.position) < 3.5f)
        {
            target.GetComponent<Target>().ChangePosition = true;
        }
        else
        {
            target.GetComponent<Target>().ChangePosition = false;
        }
        
        Vector3 direction = (target.position - transform.position).normalized;
        Vector3 euler = Quaternion.LookRotation(direction).eulerAngles;
        
        Vector3 modifiedEuler = new Vector3(euler.x, 90f, euler.z);
        Quaternion targetRotation = Quaternion.Euler(euler);
        Quaternion newRotation = Quaternion.RotateTowards(rb.rotation, targetRotation, rotateSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(newRotation);
        rb.linearVelocity = transform.forward * speed * (float)neuroskyGUIManager.meditationValue / gameManager.reqFocus;

    }

    private void OnTriggerEnter()
    {

        GameObject explosionInstance = Instantiate(explosion,transform.position,transform.rotation);
        //FindAnyObjectByType<AudioManager>().StopPlaying("BurningRocket");
        FindAnyObjectByType<AudioManager>().Play("BombExplosion");

        Destroy(gameObject);
        Destroy(explosionInstance, 1f);
        //StartCoroutine(DestroyAfterDelay(explosionInstance, 1f));
    }
    private void OnDisable()
    {
        //FindAnyObjectByType<AudioManager>().StopPlaying("BurningRocket");
    }
}
