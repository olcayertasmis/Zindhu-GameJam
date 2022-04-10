using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour
{
    Animator ChildAnim;
    private void Start()
    {
        ChildAnim.SetBool("run", true);
    }
}
