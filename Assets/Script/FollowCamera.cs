using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform Player;

    private void LateUpdate()
    {
        if(!Player.GetComponent<Player>().deadd)
        {
            transform.position = new Vector3(transform.position.x, Player.transform.position.y + 3.5f, Player.transform.position.z + -7f);
        }
    }
}
