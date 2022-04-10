using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 10.0F;

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            b();
        }
    }

    void b()
    {
        Vector3 explosionPos = new Vector3(transform.position.x,transform.position.y,transform.position.z - 1f);
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 1f);
        }
    }
}
