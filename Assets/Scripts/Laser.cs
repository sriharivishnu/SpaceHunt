using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(Light))]
public class Laser : MonoBehaviour
{
    [SerializeField] float laserOffTime = .05f;
    [SerializeField] float maxDistance = 300f;
    [SerializeField] float fireDelay = 1f;
    LineRenderer lr;
    Light laserLight;
    bool canFire = false;

    Transform myT;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        laserLight = GetComponent<Light>();
        myT = transform;
    }

    private void Start()
    {
        lr.enabled = false;
        laserLight.enabled = false;
        canFire = true;
    }

    //private void Update()
    //{
    //    Debug.DrawRay(myT.position, myT.TransformDirection(Vector3.forward) * maxDistance, Color.yellow);
    //}

    Vector3 CastRay()
    {
        RaycastHit hit;
        Vector3 fwd = myT.TransformDirection(Vector3.forward) * maxDistance;
        if (Physics.Raycast(transform.position, fwd, out hit))
        {
            Debug.Log("We hit: " + hit.ToString());
            Explosion temp = hit.transform.GetComponent<Explosion>();
            if (temp != null)
            {
                temp.ExplodeAt(hit.point);
            }
            return hit.point;
        }
        Debug.Log("We missed...");
        return myT.position + myT.forward * maxDistance;


    }

    public void FireLaser()
    {
        FireLaser(CastRay());

    }

    public void FireLaser(Vector3 targetPosition)
    {
        if (canFire)
        {
            lr.SetPosition(0, myT.position);
            lr.SetPosition(1, targetPosition);
            lr.enabled = true;
            laserLight.enabled = true;
            canFire = false;
            Invoke("TurnOffLaser", laserOffTime);
            Invoke("CanFire", fireDelay);
        }

    }

    void TurnOffLaser()
    {
        lr.enabled = false;
        laserLight.enabled = false;
    }

    public float Distance
    {
        get { return maxDistance;  }
    }

    void CanFire()
    {
        canFire = true;
    }
}
