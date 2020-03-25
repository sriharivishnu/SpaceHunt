using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] float minScale = 8.8f;
    [SerializeField] float maxScale = 10.2f;
    [SerializeField] float rotationOffset = 50f;

    Transform myT;
    Vector3 randomRotation;

    [SerializeField] float tumble;

    void Awake()
    {
        myT = transform;   
    }

    void Start()
    {
        myT.localScale = generateRandomVector(minScale, maxScale);

        randomRotation = generateRandomVector(-rotationOffset, rotationOffset);

        //GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;

    }

    void Update()
    {
        myT.Rotate(randomRotation * Time.smoothDeltaTime);
    }

    Vector3 generateRandomVector(float min, float max)
    {
        Vector3 vector = Vector3.one;
        vector.x = Random.Range(min, max);
        vector.y = Random.Range(min, max);
        vector.z = Random.Range(min, max);
        return vector;
    }
}
