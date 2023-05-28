using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun2 : MonoBehaviour
{
        //INSTANTIATE TAPOS ADDFORCE SA OBJECT KASO MINSAN HINDI NAG-TITRIGGER SA COLLISION BALIW UNITY
    [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private GameObject bulletPoint;
    public float fireRate = 1f;
    public float bulletSpeed = 100f;
    private float nextFire = 0f;

    public ParticleSystem muzzleFlash;
    


    void Update()
    {
         if(Input.GetButton("Fire1") && Time.time >= nextFire){
    nextFire = Time.time + 1f/fireRate;
    
        Shoot2();
        muzzleFlash.Play(); 
    }

    }
void Shoot2(){
    //Instantiate(muzzleFlash, bulletPoint.transform.position, transform.rotation);
  GameObject bullet = Instantiate(bulletPrefab, bulletPoint.transform.position, transform.rotation);
  bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
Destroy(bullet, 1.25f);
}
}
