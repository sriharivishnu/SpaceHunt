using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class FollowCam : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 defaultDistance = new Vector3(0f, 3f, -27f);
    [SerializeField] float distanceDamp = 10f;
    [SerializeField] float rotationDamp = 10f;

    public Vector3 velocity = Vector3.one;

    Transform myT;

    private void Awake()
    {
        myT = transform;
    }

    private void LateUpdate()
    {
        Vector3 toPos = target.position + (target.rotation * defaultDistance);
        Vector3 curPos = Vector3.Lerp(myT.position, toPos, distanceDamp * Time.deltaTime);
        myT.position = curPos;

        Quaternion toRot = Quaternion.LookRotation(target.position - myT.position, target.up);
        Quaternion curRot = Quaternion.Slerp(myT.rotation, toRot, rotationDamp * Time.deltaTime);
        myT.rotation = curRot;

        //Vector3 toPos = target.position + (target.rotation * defaultDistance);
        //Vector3 curPos = Vector3.SmoothDamp(myT.position, toPos, ref velocity, distanceDamp * Time.deltaTime);
        //myT.position = curPos;

        //myT.LookAt(target, target.up);
    }
}
