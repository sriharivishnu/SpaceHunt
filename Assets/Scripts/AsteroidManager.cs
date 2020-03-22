using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] public Asteroid[] asteroids;
    [SerializeField] int numberOfAsteroids = 5;
    [SerializeField] int gridSpacing = 25;

    private void Start()
    {
        PlaceAsteroids();
    }

   float getAsteroidZ (int x, int y)
    {
        return (Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
    }

    void PlaceAsteroids()
    {

        for (int x = -numberOfAsteroids; x < numberOfAsteroids; x++)
        {
            for (int y = -numberOfAsteroids; y < numberOfAsteroids; y++)
            {
                InstantiateAsteroid(x, y, getAsteroidZ(x, y));
               
            }
        }
    }

    void InstantiateAsteroid(int x, int y, float z)
    {
        Vector3 position = new Vector3(transform.position.x + x * gridSpacing + AsteroidOffset(),
                                        transform.position.y + y * gridSpacing + AsteroidOffset(),
                                        transform.position.z + z * gridSpacing + AsteroidOffset());
        Asteroid a = asteroids[Random.Range(0, asteroids.Length)];
        Instantiate(a, position, Quaternion.identity, transform);
    }

    float AsteroidOffset()
    {
        return Random.Range(-gridSpacing / 2f, gridSpacing / 2f);
    }
}
