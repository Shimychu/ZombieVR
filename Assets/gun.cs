using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{

    public const int MAX_AMMO = 12;
    public float speed = 40;

    public TMPro.TextMeshProUGUI GunText;
    public GameObject bullet;
    public Transform barrel;
    public AudioSource audioGun;
    public AudioClip audioGunFire;
    public AudioClip audioGunEmpty;
    public int bulletCount = MAX_AMMO;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Angle(transform.up, Vector3.up) > 100)
        {
            Reload();
        }
        GunText.text = bulletCount.ToString();
    }

    public void Fire()
    {
        
        if(bulletCount > 0)
        {
            bulletCount--;
            GameObject spawnedBullet = Instantiate(bullet, barrel.position, barrel.rotation);
            spawnedBullet.GetComponent<Rigidbody>().velocity = speed * barrel.forward * 2;
            audioGun.PlayOneShot(audioGunFire);
            Destroy(spawnedBullet, 2);
        } else
        {
            audioGun.PlayOneShot(audioGunEmpty);
        }
    }

    void Reload()
    {
        bulletCount = MAX_AMMO;
        
    }
}
