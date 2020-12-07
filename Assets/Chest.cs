using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    BoxCollider ChestHitBox;
    // Start is called before the first frame update
    void Start()
    {
        ChestHitBox = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Hit()
    {
        GetComponentInParent<zombie>().Hit(40);
        if (GetComponentInParent<zombie>().isZombieDead())
        {
            Destroy(this);
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HIT CHEST???");
        if (collision.collider == ChestHitBox)
        {
            if (collision.gameObject.CompareTag("Weapon"))
            {
                Hit();
                Debug.Log("HIT CHEST");
            }
        }

    }

}
