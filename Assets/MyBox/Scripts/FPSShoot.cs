using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class FPSShoot : MonoBehaviour
{
    public bool disabled = false;
    public Camera cam;
    private Vector3 destination;

    public bool normalGun;
    public bool rpgGun;

    // normal gun //
    public GameObject gun;
    public GameObject bullet;
    public GameObject muzzle;
    public Transform FirePoint;
    public float projectileSpeed = 30;
    public float timeToFire;
    public float fireRate = 4;

    // rpg gun //
    public GameObject rpg;
    public GameObject rpgBullet;
    public GameObject muzzleRpg;
    public Transform rpgFirePoint;
    public float rpgProjectileSpeed = 30;
    public float rpgTimeToFire;
    public float rpgFireRate = 4;



    public bool gunBool = false;
    void Start()
    {

    }


    void Update()
    {
        if (normalGun)
        {
            gun.SetActive(true);
            rpg.SetActive(false);
            rpgGun = false;


        }
        if (rpgGun)
        {
            rpg.SetActive(true);
            gun.SetActive(false);
            normalGun = false;

        }


        if (!disabled && gunBool)
        {
            if (Input.GetButton("Fire1") && Time.time >= timeToFire && normalGun)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
                GunShake();
            }

            if (Input.GetButton("Fire1") && Time.time >= rpgTimeToFire && rpgGun)
            {
                rpgTimeToFire = Time.time + 1 / rpgFireRate;
                RPGShoot();
                RPGGunShake();
            }
        }



        if (Input.GetKey(KeyCode.Alpha1))
        {
            rpgGun = false;
            normalGun = true;

        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            normalGun = false;
            rpgGun = true;


        }

    }

    private void Shoot()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
            destination = hit.point;
        else
            destination = ray.GetPoint(1000);
        InstantiateBullet(FirePoint);

    }

    private void RPGShoot()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
            destination = hit.point;
        else
            destination = ray.GetPoint(1000);
        InstantiateRPGBullet(rpgFirePoint);

    }
    async void GunShake()
    {

        gun.transform.Rotate(0f, 0.0f, 2.0f, Space.Self);
        await Task.Delay(150);
        gun.transform.Rotate(0f, 0.0f, -2.0f, Space.Self);
    }

    async void RPGGunShake()
    {

        rpg.transform.Rotate(0.5f, 0.5f, 5.0f, Space.Self);
        await Task.Delay(150);
        rpg.transform.Rotate(-0.5f, -0.5f, -5.0f, Space.Self);
    }

    void InstantiateBullet(Transform firePoint)
    {
        var bulletObj = Instantiate(bullet, firePoint.position, Quaternion.identity) as GameObject;
        bulletObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;

        var muzzleObj = Instantiate(muzzle, firePoint.position, Quaternion.identity) as GameObject;
        Destroy(muzzleObj, 2);

    }

    void InstantiateRPGBullet(Transform rpgFirePoint)
    {
        var bulletObj = Instantiate(rpgBullet, rpgFirePoint.position, Quaternion.identity) as GameObject;
        bulletObj.GetComponent<Rigidbody>().velocity = (destination - rpgFirePoint.position).normalized * rpgProjectileSpeed;

        var muzzleObj = Instantiate(muzzleRpg, rpgFirePoint.position, Quaternion.identity) as GameObject;
        Destroy(muzzleObj, 2);

    }


}
