using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Growth : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            Grow(-0.1f);
        }

        if (Input.GetKey(KeyCode.G))
        {
            Grow(20);
        }
    }

    public void Grow(float a)
    {
        float orjboyut = transform.localScale.x;
        float MatematikOgreniyorum = (orjboyut * a / 100) + orjboyut;
        transform.DOScale(MatematikOgreniyorum, 1f);
    }
}
