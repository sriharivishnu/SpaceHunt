using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float movementSpeed = 20f;
    [SerializeField] float rotationalDamp = .5f;

    [SerializeField] float detectionDistance = 20f;
    [SerializeField] float rayCastOffset = 2.5f;


    Transform myT;

    private void Awake()
    {
        myT = transform;
    }

    private void Update()
    {
        //Turn();
        Move();
        PathFinding();
    }

    void Turn()
    {
        Vector3 pos = target.position - myT.position;
        Quaternion rotation = Quaternion.LookRotation(pos);

        myT.rotation = Quaternion.Slerp(myT.rotation, rotation, Time.deltaTime * rotationalDamp);
    }

    void Move()
    {
        myT.position += myT.forward * movementSpeed * Time.deltaTime;
    }

    void PathFinding()
    {
        RaycastHit hit;
        Vector3 newPos = Vector3.zero;
        Vector3 left = transform.position - transform.right * rayCastOffset;
        Vector3 right = transform.position + transform.right * rayCastOffset;

        Vector3 up = transform.position + transform.up * rayCastOffset;
        Vector3 down = transform.position - transform.up * rayCastOffset;

        Debug.DrawRay(left, transform.forward * detectionDistance, Color.cyan);
        Debug.DrawRay(right, transform.forward * detectionDistance, Color.cyan);

        Debug.DrawRay(up, transform.forward * detectionDistance, Color.cyan);
        Debug.DrawRay(down, transform.forward * detectionDistance, Color.cyan);

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
            transform.Rotate(newPos * 5f * Time.deltaTime);
        }
        else
        {
            Turn();
        }


    }
}
