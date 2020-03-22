using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Explosion : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] float destroyTime = 6f;
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] float forceStrength = 5f;

    //bool exploding = false;


    public void ExplodeAt(Vector3 pos)
    {
        GameObject go = Instantiate(explosion, pos, Quaternion.identity, transform) as GameObject;
        Destroy(go, destroyTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach(ContactPoint contact in collision.contacts)
        {
            ExplodeAt(contact.point);
           
        }
        
    }

    public void AddForce(Vector3 hitPosition, Transform hitSource)
    {
        ExplodeAt(hitPosition);
        if (rigidBody == null) return;
        Vector3 direction = hitPosition - hitSource.position;

        rigidBody.AddForceAtPosition(direction.normalized * forceStrength, hitPosition, ForceMode.Impulse);

    }
}
