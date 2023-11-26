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
    public GameObject gun;
    public GameObject bullet;
    public GameObject muzzle;
    public Transform FirePoint;
    public float projectileSpeed = 30;
    public float timeToFire;
    public float fireRate = 4;
    void Start()
    {

    }


    void Update()
    {
        if (!disabled)
        {
            if (Input.GetButton("Fire1") && Time.time >= timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
                GunShake();
            }
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
    async void GunShake()
    {
        gun.transform.Rotate(0f, 0.0f, 2.0f, Space.Self);
        await Task.Delay(150); 
        gun.transform.Rotate(0f, 0.0f, -2.0f, Space.Self);
    }

    void InstantiateBullet(Transform firePoint)
    {
        var bulletObj = Instantiate(bullet, firePoint.position, Quaternion.identity) as GameObject;
        bulletObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;

        var muzzleObj = Instantiate(muzzle, firePoint.position, Quaternion.identity) as GameObject;
        Destroy(muzzleObj, 2);

    }
}
