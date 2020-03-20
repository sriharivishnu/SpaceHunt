using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float movementSpeed = 20f;
    [SerializeField] float rotationalDamp = .5f;

    Transform myT;

    private void Awake()
    {
        myT = transform;
    }

    private void Update()
    {
        Turn();
        Move();
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
}
