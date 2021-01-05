using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float spawnTime = 1;
    public GameObject spawnGameObject;
    public Transform[] spawnPoints;
    private float timer;
    private bool nextWave = false;
    private int totalZombies = 10;
    public AudioClip openingAudio;

    // Start is called before the first frame update
    void Start()
    {
        nextWave = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(nextWave)
        {
            nextWave = false;
            StartCoroutine(WaitOpening());
            StartCoroutine(WaitZombie());
        }
    }

    IEnumerator WaitZombie()
    {
        yield return new WaitForSeconds(6);
        for (int i = 0; i < totalZombies; i++)
        {
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(spawnGameObject, randomPoint.position, randomPoint.rotation);
            yield return new WaitForSeconds(2); 
        }
        totalZombies = totalZombies + 10;
    }

    IEnumerator WaitOpening()
    {
        for(int i = 0; i < 3; i++)
        {
            GetComponent<AudioSource>().PlayOneShot(openingAudio);
            yield return new WaitForSecondsRealtime(2);
        }
        Debug.Log("waiting 3 seconds");
    }
}
