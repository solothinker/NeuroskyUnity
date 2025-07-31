using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;

public class TargetFollowCamera : MonoBehaviour
{
    private CinemachineCamera CineCam;
    private Transform target;
    private Transform missile;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CineCam = GetComponent<CinemachineCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        missile = GameObject.FindGameObjectWithTag("Missile").transform;
        if(target != null && missile != null)
        {
            CineCam.LookAt = target;
            CineCam.Follow = missile;
        }
    }
}
