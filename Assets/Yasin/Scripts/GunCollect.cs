using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCollect : MonoBehaviour
{
    FPSShoot fPSShoot;
    public GameObject gun;
    public GameObject rpg;
    public GameObject croshair;
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
            fPSShoot.normalGun = true;
            gun.gameObject.SetActive(true);
            croshair.gameObject.SetActive(true);
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            rpg.SetActive(false);
            fPSShoot.rpgGun = false;
            Destroy(gameObject, 10f);
        }
    }



}
