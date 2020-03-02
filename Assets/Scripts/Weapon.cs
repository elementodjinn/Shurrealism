using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Transform player;
    public float cooldown = 1;
    public float coolDownTimer;

    private GameObject bulletInstance; //i added this idfk what it does

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (coolDownTimer > 0)
            coolDownTimer -= Time.deltaTime;
        if (coolDownTimer < 0)
            coolDownTimer = 0;
        if (Input.GetButtonDown("Fire1") && coolDownTimer == 0)
        {

            Shoot();
            coolDownTimer = cooldown;
        }


    }

    void Shoot()
    {
        /*bulletInstance = Instantiate(bulletPrefab);
        var bodyStuff = bulletInstance.GetComponent<Rigidbody2D>();
        Player_Movement.transform.up
        Instantiate(bulletPrefab, firePoint.position, transform.up );*/
        //munitionRigidBody.velocity = player.transform.up * _shootForce;
        Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);


    }
}
