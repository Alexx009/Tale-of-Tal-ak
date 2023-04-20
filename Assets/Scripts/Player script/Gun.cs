
using UnityEngine;

public class Gun : MonoBehaviour
{

    //RAYCAST FIRING ON POINT TO MASYADO
   public float damage = 10f;
   public float range = 100f;

   public ParticleSystem muzzleFlash;

   public GameObject impactEffect;
public Camera fpsCam;
public float fireRate = 15f;
private float nextTimeToFire = 0f;
    // Update is called once per frame

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
            muzzleFlash.Play();
            
        }
        
    }

    void Shoot(){
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if(target!= null)
            {
                GameObject impactGO = Instantiate(impactEffect, hit.point,Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 1.5f);
                target.TakeDamage(damage);
            }
           
        }
    }
}
