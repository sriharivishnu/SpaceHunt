using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
    [SerializeField] float laserOffTime = .4f;
    [SerializeField] float maxDistance = 300f;
    LineRenderer lr;
    bool canFire = false;

    Transform myT;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        myT = transform;
    }

    private void Start()
    {
        lr.enabled = false;
    }

    //private void Update()
    //{
    //    FireLaser(myT.position + myT.forward * maxDistance);
    //}

    public void FireLaser(Vector3 targetPos)
    {
        if (canFire)
        {
            lr.SetPosition(0, myT.position);
            lr.SetPosition(1, targetPos);
            lr.enabled = true;
            canFire = false;
        }

        Invoke("TurnOffLaser", laserOffTime);
    }

    void TurnOffLaser()
    {
        lr.enabled = false;
        canFire = true;
    }
}
