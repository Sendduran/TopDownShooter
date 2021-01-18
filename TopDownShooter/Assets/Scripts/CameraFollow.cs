using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update


    private Transform playerPos;
    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerPos.position.x, playerPos.position.y, transform.position.z);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10.42f, 10.42f), Mathf.Clamp(transform.position.y, -5.85f, 5.85f), transform.position.z);
    }
}
