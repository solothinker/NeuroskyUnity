using System;
using System.Collections;
using MindWave;
using TMPro;
using UnityEngine;

public class GameObjectInstantiate : MonoBehaviour
{
    public GameObject missile;
    public GameObject target;
    private GameObject _missile = null,_target = null;
    private int value = 4;
    private Rigidbody rbm,rbt;
    public GameObject CameraMan;
    private GameManager manager;
    public TextMeshProUGUI[] UIText;
    private ButtonSelector buttonSelector;
    private NeuroskyGUIManager neuroskyGUIManager;
    // public TextMeshProUGUI Distance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = FindFirstObjectByType<GameManager>();
        buttonSelector = FindAnyObjectByType<ButtonSelector>();
        neuroskyGUIManager = FindAnyObjectByType<NeuroskyGUIManager>();
        SpwanMyGameObject(target);
        StartCoroutine(DelaySpwan());
    }

    // Update is called once per frame
    void Update()
    {
        if (_target == null && _missile == null && manager.count == 2)
        {
            //SpwanMyGameObject(target);
            SpwanMyGameObject(target);
            StartCoroutine(DelaySpwan());
        }       
    }
    private void FixedUpdate()
    {
        int speed = (int)(rbm.linearVelocity.magnitude * 100);
        UIText[0].text = "Speed = " + speed + " Km/hr";

        int dist = (int)Vector3.Distance(rbm.transform.position, rbt.transform.position);
        UIText[1].text = "Distance = " + dist + " m";

        UIText[2].text = "Req Attention = " + buttonSelector.reqFocus;
        UIText[3].text = "Cur Attention = " + neuroskyGUIManager.attentionValue;
    }

    private void SpwanMyGameObject(GameObject MyGO)
    {
        if (String.Compare(MyGO.name, "Target")==0)
        {
            var pos = new Vector3(UnityEngine.Random.Range(-value*10, value*10), 0, UnityEngine.Random.Range(-value, value));
            _target = Instantiate(MyGO, pos, Quaternion.identity);
            rbt = _target.GetComponent<Rigidbody>();
            
        }
        else
        {
            var pos = new Vector3(UnityEngine.Random.Range(-value * 10, value * 10), 0, UnityEngine.Random.Range(-value, value));
            Quaternion rot = Quaternion.Euler(0f, 0f, 0f);
            _missile = Instantiate(MyGO, pos, rot);
            rbm = _missile.GetComponent<Rigidbody>();
        }
        
    }

    IEnumerator DelaySpwan()
    {
        
        yield return new WaitForSeconds(2f);
        SpwanMyGameObject(missile);
    }
}
