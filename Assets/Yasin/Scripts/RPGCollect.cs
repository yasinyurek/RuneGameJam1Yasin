using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGCollect : MonoBehaviour
{
    FPSShoot fPSShoot;
    public GameObject rpg;
    public GameObject gun;
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
            fPSShoot.rpgGun = true;
            rpg.gameObject.SetActive(true);
            croshair.gameObject.SetActive(true);
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            gun.SetActive(false);
            fPSShoot.normalGun = false;
            Destroy(gameObject, 10f);
        }
    }



}
