using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombie : MonoBehaviour
{

    public Transform target;
    public int ZombieHealth;
    private bool isDead = false;

    public AudioClip zombieAudio;
    public AudioClip zombieDeathAudio;

    private NavMeshAgent agent;
    private Rigidbody[] rbs;

    public static int deadZombieCount = 0;

    // Start is called before the first frame update
    void Start()
    {

        ZombieHealth = 100;

        rbs = GetComponentsInChildren<Rigidbody>();

        // Get zombie to follow XRRig
        agent = GetComponent<NavMeshAgent>();

        // Set it so that the zombie's speed 2/3 of zombies will be slower type, while 1/3 will be faster type.
        int odds = Random.Range(0, 3);
        if(odds < 2)
        {
            agent.speed = Random.Range(0.15f, 0.35f);
        }
        else
        {
            agent.speed = Random.Range(0.25f, 1.00f);
        }
        target = FindObjectOfType<UnityEngine.XR.Interaction.Toolkit.XRRig>().transform;

        DeactivateRageDoll();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);

        if (Vector3.Distance(target.position, transform.position) < 1.5f)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }

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
        deadZombieCount++;
        ActivateRageDoll();
        agent.enabled = false;
        GetComponent<Animator>().enabled = false;
        GetComponent<AudioSource>().PlayOneShot(zombieDeathAudio);
        Destroy(gameObject,10);
        Destroy(this);
    }

    public bool isZombieDead()
    {
        return isDead;
    }


    public void Hit(int damage)
    {
        GetComponent<AudioSource>().PlayOneShot(zombieAudio);
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

    public static int getDeadZombie()
    {
        return deadZombieCount;
    }

    public static void resetDeadZombieCount()
    {
        deadZombieCount = 0;
    }
}
