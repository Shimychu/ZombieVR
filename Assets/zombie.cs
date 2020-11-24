using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour
{

    private Rigidbody[] rbs;

    // Start is called before the first frame update
    void Start()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
        DeactivateRageDoll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ActivateRageDoll()
    {
        foreach (var item in rbs)
        {
            item.isKinematic = false;
        }
    }

    void DeactivateRageDoll()
    {
        foreach (var item in rbs)
        {
            item.isKinematic = true;
        }
    }
}
