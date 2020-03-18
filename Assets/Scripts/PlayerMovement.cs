using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Transform myT;
    [SerializeField] float movementSpeed = 50f;
    [SerializeField] float turnSpeed = 60f;

    void Awake()
    {
        myT = transform;
    }

    void Update()
    {
        Thrust();
        Turn();
    }

    void Turn()
    {
        float yaw = -turnSpeed * Time.deltaTime * Input.GetAxis("Roll");
        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Pitch");
        myT.Rotate(pitch, 0, yaw);
    }

    void Thrust()
    {
        if (Input.GetAxis("Thrust") > 0)
        {
            transform.position += transform.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Thrust");
        }

    }
}
