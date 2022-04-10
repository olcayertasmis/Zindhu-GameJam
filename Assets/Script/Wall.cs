using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Wall : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 10.0F;

    public void EnableRigidbody(bool b)
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).GetComponent<Rigidbody>())
            {
                transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = b;
            }
        }
        bomb();
    }

    void bomb()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null && hit.transform.tag != "Player")
                rb.AddExplosionForce(power, explosionPos, radius, 1f);
        }
        StartCoroutine("IEDestroyBricks");
    }

    IEnumerator IEDestroyBricks()
    {
        yield return new WaitForSeconds(0.75f);
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).DOScale(new Vector3(0f,0f,0f),0.75f);
        }
    }
}
