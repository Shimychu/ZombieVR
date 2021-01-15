using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legs : MonoBehaviour
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
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Hit(30);
            Debug.Log("HIT LEGS");
        }
        if (collision.gameObject.CompareTag("GoldenWeapon"))
        {
            Hit(1000);
        }
    }
}
