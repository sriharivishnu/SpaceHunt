using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerMovement : MonoBehaviour
{
    Transform myT;
    [SerializeField] float movementSpeed = 50f;
    [SerializeField] float turnSpeed = 60f;
    public Thruster[] thruster;

    bool thrusterEnabled = false;

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
        if (Input.acceleration.x != 0 || Input.acceleration.y != 0)
        {
            float roll = -turnSpeed * Time.smoothDeltaTime * Input.acceleration.x;
            float pitch = -turnSpeed * Time.smoothDeltaTime * Input.acceleration.z;
            myT.Rotate(pitch, 0, roll);
        }
        else
        {
            float roll = -turnSpeed * Time.smoothDeltaTime * Input.GetAxis("Roll");
            float pitch = turnSpeed * Time.smoothDeltaTime * Input.GetAxis("Pitch");
            myT.Rotate(pitch, 0, roll);
        }
    }

    void Thrust()
    {
        if (true)
        {
            transform.position += transform.forward * movementSpeed * Time.smoothDeltaTime;
            foreach (Thruster t in thruster)
            {
                t.Intensity(1f);
            }

        }

        //if (!thrusterEnabled)
        //{
        //    foreach (Thruster t in thruster)
        //    {
        //        t.Activate();
        //    }
        //    thrusterEnabled = true;
        //}

    }
}
