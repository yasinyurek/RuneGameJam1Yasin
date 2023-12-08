using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    Vector2 velocity;
    public float smoothTimeX;

    public bool bounds;
    public Vector3 minCamPos;
    public Vector3 maxCamPos;

    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void FixedUpdate()
    {
        CameraSmooth();
        CameraBounds();
    }

    void CameraSmooth()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);

        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }

    void CameraBounds()
    {
        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCamPos.x, maxCamPos.x),
                                            (transform.position.y),
                                            transform.position.z);

        }
    }
}
