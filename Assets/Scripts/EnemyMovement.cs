using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float movementSpeed = 30f;
    [SerializeField] float rotationalDamp = .8f;

    [SerializeField] float detectionDistance = 30f;
    [SerializeField] float rayCastOffset = 6.5f;


    Transform myT;

    private void Awake()
    {
        myT = transform;
    }

    private void Update()
    {
        //Turn();
        if (!FindTarget())
            return;
        PathFinding();
        Move();
    }

    void Turn()
    {   
        Vector3 pos = target.position - myT.position;
        Vector3 to = new Vector3(target.position.x, target.position.y, myT.position.z);
        Debug.DrawLine(myT.position, to, Color.blue);
        Quaternion rotation = Quaternion.LookRotation(pos);

        myT.rotation = Quaternion.Slerp(myT.rotation, rotation, Time.smoothDeltaTime * rotationalDamp);
        //myT.Rotate(0, 0, -Mathf.Atan(pos.y / pos.x)*Time.smoothDeltaTime*100f);
        //myT.rotation = Quaternion.FromToRotation(Vector3.up, pos);
        
    }

    void Move()
    {
        myT.position += myT.forward * movementSpeed * Time.smoothDeltaTime;
    }

    void PathFinding()
    {
        RaycastHit hit;
        Vector3 newPos = Vector3.zero;
        Vector3 left = transform.position - transform.right * rayCastOffset;
        Vector3 right = transform.position + transform.right * rayCastOffset;

        Vector3 up = transform.position + transform.up * rayCastOffset;
        Vector3 down = transform.position - transform.up * rayCastOffset;

        //Debug.DrawRay(left, transform.forward * detectionDistance, Color.cyan);
        //Debug.DrawRay(right, transform.forward * detectionDistance, Color.cyan);

        //Debug.DrawRay(up, transform.forward * detectionDistance, Color.cyan);
        //Debug.DrawRay(down, transform.forward * detectionDistance, Color.cyan);

        if (Physics.Raycast(left, transform.forward, out hit, detectionDistance))
            newPos += Vector3.right;
        
        else if (Physics.Raycast(right, transform.forward, out hit, detectionDistance))
            newPos -= Vector3.right;

        if (Physics.Raycast(up, transform.forward, out hit, detectionDistance))
            newPos -= Vector3.up;

        else if (Physics.Raycast(down, transform.forward, out hit, detectionDistance))
            newPos += Vector3.up;

        if (newPos != Vector3.zero)
        {
            transform.Rotate(newPos * 5f * Time.smoothDeltaTime);
        }
        else
        {
            Turn();
        }


    }

    bool FindTarget()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;

            if (target == null)
            {
                return false;
            }
        }
        return true;
    }
}
