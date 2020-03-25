using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mothership : MonoBehaviour
{
    [SerializeField] float movementSpeed = 2f;
    Transform myT;
    private void Awake()
    {
        myT = transform;
    }

    private void Update()
    {
        myT.position += myT.forward * movementSpeed * Time.smoothDeltaTime;
    }
}
