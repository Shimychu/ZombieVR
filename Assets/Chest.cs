using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Hit(int dmg)
    {
        GetComponentInParent<zombie>().Hit(dmg);
        if (GetComponentInParent<zombie>().isZombieDead())
        {
            Destroy(this);
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        //Debug.Log("HIT CHEST???");
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Hit(50);
            Debug.Log("HIT CHEST");
        }
        if (collision.gameObject.CompareTag("GoldenWeapon"))
        {
            Hit(1000);
        }
    }

}
