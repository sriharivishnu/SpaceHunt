using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] int currHealth;
    [SerializeField] float regenerationRate = 2f;
    [SerializeField] int regenerateAmount = 10;

    private void Start()
    {
        currHealth = maxHealth;

        InvokeRepeating("Regenerate", regenerationRate, regenerationRate);
    }

     void Regenerate()
    {
        if (currHealth < maxHealth)
        {
            currHealth += regenerateAmount;
        }
        if (currHealth > maxHealth) 
        {
            currHealth = maxHealth;
        }
    }

    public void TakeDamage(int dmg = 10)
    {
        currHealth -= dmg;
        if (currHealth <= 0)
        {
            Debug.Log("I B DED!");
        }

    }

}
