using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float LeftLimit, RightLimit;

    public GameObject player;
    void Update()
    {
        if (player.transform.position.x > transform.position.x && transform.position.x < RightLimit)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
        
       if (player.transform.position.x < transform.position.x && transform.position.x > LeftLimit)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
