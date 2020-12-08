﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetAndHands : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Hit()
    {
        GetComponentInParent<zombie>().Hit(10);
        if (GetComponentInParent<zombie>().isZombieDead())
        {
            Destroy(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Hit();
            Debug.Log("HIT Feet/Hands");
        }
    }
}