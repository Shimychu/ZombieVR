using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.AI;

public class zombie : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    private Rigidbody[] rbs;

    // Start is called before the first frame update
    void Start()
    {
        rbs = GetComponentsInChildren<Rigidbody>();

        // Get zombie to follow XRRig
        agent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<UnityEngine.XR.Interaction.Toolkit.XRRig>().transform;

        DeactivateRageDoll();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
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
