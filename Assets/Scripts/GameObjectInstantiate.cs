using System;
using System.Collections;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class GameObjectInstantiate : MonoBehaviour
{
    public GameObject missile;
    public GameObject target;
    private GameObject _missile = null,_target = null;
    private int value = 4;
    private Rigidbody rb;
    public GameObject CameraMan;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpwanMyGameObject(target);
        SpwanMyGameObject(missile);

    }

    // Update is called once per frame
    void Update()
    {       
        if (_target == null) SpwanMyGameObject(target);
        if (_missile == null) SpwanMyGameObject(missile);
        Debug.Log(rb.linearVelocity.magnitude);
    }

    private void SpwanMyGameObject(GameObject MyGO)
    {
        if (String.Compare(MyGO.name, "Target")==0)
        {
            var pos = new Vector3(UnityEngine.Random.Range(-value*10, value*10), 0, UnityEngine.Random.Range(-value, value));
            _target = Instantiate(MyGO, pos, Quaternion.identity);
        }
        else
        {
            var pos = new Vector3(UnityEngine.Random.Range(-value * 10, value * 10), 0, UnityEngine.Random.Range(-value, value));
            Quaternion rot = Quaternion.Euler(0f, 0f, 0f);
            _missile = Instantiate(MyGO, pos, rot);
            rb = _missile.GetComponent<Rigidbody>();
        }
    }
}
