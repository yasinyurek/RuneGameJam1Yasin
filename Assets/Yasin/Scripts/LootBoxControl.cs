using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBoxControl : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Open", true);

            if (this.gameObject.CompareTag("GunBox") == false)
            {
                Destroy(gameObject, 10f);

            }
        }


    }
}
