using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public GameObject hitVFX;
    private bool collided;

    public int enemyCounter;
    public void OnCollisionEnter(Collision coll)
    {
        if (!coll.gameObject.CompareTag("Bullet") && !coll.gameObject.CompareTag("Player") && !collided)
        {
            collided = true;
            var hit = Instantiate(hitVFX, coll.contacts[0].point, Quaternion.identity);
            Destroy(hit, 2);
            Destroy(gameObject);
        }



    }


}
