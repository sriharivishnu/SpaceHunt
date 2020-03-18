using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class Thruster : MonoBehaviour
{
    TrailRenderer tr;

    private void Awake()
    {
        tr = GetComponent<TrailRenderer>();
    }

    public void Activate(bool activate = true)
    {
        if (activate)
        {
            tr.enabled = true;
        }
        else
        {
            tr.enabled = false;
        }
    }
}
