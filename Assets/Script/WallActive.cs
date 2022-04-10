using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WallActive : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            StartCoroutine("IEactiveWall");
        }
    }

    IEnumerator IEactiveWall()
    {
        Transform t = transform.parent;
        for(int i = 0; i < t.childCount; i++)
        {
            yield return new WaitForSeconds(0.05f);
            t.GetChild(i).DOScale(new Vector3(0.6f,0.4f,0.25f),0.05f);
        }
    }
}
