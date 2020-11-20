using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Bullet Components
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed;
    [SerializeField] float timeBetweenShots;
    [SerializeField] float timeBetweenShotsCounter;
    public Vector3 bulletOffset;
    bool canFire = true;

    private void Start()
    {
        timeBetweenShotsCounter = timeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {        
        {
            CountDownAndShoot();
        }
    }

    private void CountDownAndShoot()
    {
        timeBetweenShotsCounter -= Time.deltaTime;
        if (timeBetweenShotsCounter <= 0f)
        {
            Fire();
        }
    }

    private void Fire()
    {
        //     playerTarget = player.transform.position - transform.position;
        //     Quaternion playerRotation = Quaternion.LookRotation(playerTarget);
        Vector3 shootDirection = new Vector3(transform.position.x, 0f, 0f);
        // shootDirection = Vector3

        if (Input.GetKey("j") && canFire == true)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position + bulletOffset, transform.rotation)
                         as GameObject;
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
            timeBetweenShotsCounter = timeBetweenShots;
        }
    }
}
