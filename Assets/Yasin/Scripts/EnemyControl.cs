using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    Animator animator;

    public GameObject body;
    public BoxCollider boxCollider;


    void Start()
    {

        animator = GetComponent<Animator>();
        boxCollider = body.GetComponent<BoxCollider>();


    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Bullet") || coll.gameObject.CompareTag("RPGBullet"))
        {
            animator.SetBool("Dead", true);
            boxCollider.isTrigger = true;
            Destroy(gameObject, 4f);


        }
    }

}
