using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
[RequireComponent(typeof(Light))]
public class Thruster : MonoBehaviour
{
    TrailRenderer tr;
    Light thrusterLight;

    private void Awake()
    {
        tr = GetComponent<TrailRenderer>();
        thrusterLight = GetComponent<Light>();
    }

    private void Start()
    {
        tr.enabled = false;
        thrusterLight.enabled = false;
    }

    public void Activate(bool activate = true)
    {
        if (activate)
        {
            tr.enabled = true;
            thrusterLight.enabled = true;
        }
        else
        {
            tr.enabled = false;
            thrusterLight.enabled = false;
        }
    }
}
