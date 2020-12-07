using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombie : MonoBehaviour
{

    public Transform target;
    public int ZombieHealth;
    private bool isDead = false;


    private NavMeshAgent agent;
    private Rigidbody[] rbs;

    // Start is called before the first frame update
    void Start()
    {

        ZombieHealth = 100;

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

    public void Death()
    {
        ActivateRageDoll();
        agent.enabled = false;
        GetComponent<Animator>().enabled = false;
        Destroy(this);
    }

    public bool isZombieDead()
    {
        return isDead;
    }


    public void Hit(int damage)
    {
        ZombieHealth -= damage;
        if(ZombieHealth <= 0)
        {
            isDead = true;
            Death();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Debug.Log("HIT");
        }
        else
        {
            Debug.Log("NO HIT");
        }

         
    }

}
