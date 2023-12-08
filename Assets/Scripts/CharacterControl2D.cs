using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl2D : MonoBehaviour
{
    float horizontal=0;
    public int speed = 10;
    Vector3 vec;
    Rigidbody2D rb;


    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vec = new Vector3(horizontal * speed, rb.velocity.y, 0);
        rb.velocity = vec;
    }


}
