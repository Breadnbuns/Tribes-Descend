using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_spinfusor : MonoBehaviour
{
    public Camera cam;
    public GameObject projectile;
    public float projectileSpeed = 30;
    public Transform firePoint;

    public float fireRate = 1;
    public float timeToFire;

    private Vector3 destination;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= timeToFire)
        {
            timeToFire = Time.time + fireRate;
            shootProjectile();
        }
    }

    void shootProjectile()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
        }
        else
        {
            destination = ray.GetPoint(1000);
        }
        InstantiateProjectile(firePoint);
    }

    void InstantiateProjectile(Transform firePoint)
    {
        var projectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;
    }
}
