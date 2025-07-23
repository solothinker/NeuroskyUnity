using System;
using UnityEngine;

public class GameObjectInstantiate : MonoBehaviour
{
    public GameObject missile;
    public GameObject target;
    private GameObject _missile,_target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpwanMyGameObject(target);
        SpwanMyGameObject(missile);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpwanMyGameObject(GameObject MyGO)
    {
        if (String.Compare(MyGO.name, "Target")==0)
        {
            var pos = new Vector3(8,0,0);
            _target = Instantiate(MyGO, pos, Quaternion.identity);
        }
        else
        {
            var pos = new Vector3(-8, 0, 0);
            Quaternion rot = Quaternion.Euler(0f, 0f, 0f);
            _missile = Instantiate(MyGO, pos, rot);
            //_missile.transform.localScale = new Vector3(0.5f,0.5f,0.2f);
        }
    }
}
