using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public float speed = 40;
    public GameObject bullet;
    public Transform barrel;
    public AudioSource audioGun;
    public AudioClip audioGunFire;
    public AudioClip audioGunEmpty;
    public int bulletCount = 12;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        bulletCount--;
        if(bulletCount >= 0)
        {
            GameObject spawnedBullet = Instantiate(bullet, barrel.position, barrel.rotation);
            spawnedBullet.GetComponent<Rigidbody>().velocity = speed * barrel.forward;
            audioGun.PlayOneShot(audioGunFire);
            Destroy(spawnedBullet, 2);
        } else
        {
            audioGun.PlayOneShot(audioGunEmpty);
        }
    }
}
