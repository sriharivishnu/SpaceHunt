using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Laser laser;

    Vector3 hitPosition = Vector3.zero;

    private void Update()
    {
        InFront();
        HaveLineOfSight();
        if (InFront() && HaveLineOfSight())
        {
            FireLaser();
        }
    }

    bool InFront()
    {
        Vector3 directionToTarget = target.position - laser.transform.position;
        float angle = Vector3.Angle(transform.forward, directionToTarget);

        if (Mathf.Abs(angle) < 60)
        {
            //Debug.DrawLine(laser.transform.position, target.position, Color.green);
            return true;
        }
        //Debug.DrawLine(laser.transform.position, target.position, Color.yellow);
        return false;
    }

    bool HaveLineOfSight()
    {
        RaycastHit hit;

        Vector3 direction = target.position - laser.transform.position;


        if (Physics.Raycast(laser.transform.position, direction, out hit, laser.Distance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                Debug.DrawRay(laser.transform.position, direction, Color.red);
                hitPosition = hit.transform.position;
                return true;
            }
        }
        return false;
    }

    void FireLaser()
    {
        laser.FireLaser(hitPosition, target);
    }
}
