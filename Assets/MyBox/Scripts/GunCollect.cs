using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCollect : MonoBehaviour
{
    FPSShoot fPSShoot;
    public GameObject gun;
    public GameObject Player;
    void Start()
    {
        fPSShoot = Player.GetComponent<FPSShoot>();

    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            fPSShoot.gunBool = true;
            gun.gameObject.SetActive(true);
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            Destroy(gameObject, 10f);
        }
    }


}
