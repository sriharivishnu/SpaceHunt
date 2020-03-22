using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarField : MonoBehaviour
{
    [SerializeField] int starsMax = 100;
    [SerializeField] float starSize = 1f;
    [SerializeField] float starDistance = 10f;
    [SerializeField] float starClipDistance = 1f;

    private float starDistanceSqr;
    private float starClipDistanceSqr;

    private Transform myT;
    private ParticleSystem.Particle[] points;
    private ParticleSystem pSystem;

    private void Start()
    {
        myT = transform;
        starDistanceSqr = starDistance * starDistance;
        starClipDistanceSqr = starClipDistance * starClipDistance;
        pSystem = GetComponent<ParticleSystem>();
        CreateStars();
    }

    private void Update()
    {
        for (int i = 0; i < starsMax; i++)
        {
            if ((points[i].position - myT.position).sqrMagnitude > starDistanceSqr)
            {
                points[i].position = Random.insideUnitSphere.normalized * starDistance + myT.position;
            }
            if ((points[i].position - myT.position).sqrMagnitude <= starClipDistance)
            {
                float percent = (points[i].position - myT.position).sqrMagnitude / starClipDistanceSqr;
                points[i].startColor = new Color(1, 1, 1, percent);
                points[i].startSize = percent * starSize;
            }
            pSystem.SetParticles(points, points.Length);
        }
    }

    private void CreateStars()
    {
        points = new ParticleSystem.Particle[starsMax];

        for (int i = 0; i < starsMax; i++)
        {
            points[i].position = Random.insideUnitSphere * starDistance + myT.position;
            points[i].startColor = Color.white;
            
            points[i].startSize = starSize;
        }
    }
}
