﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{

    public float spawnTime = 1;
    public GameObject spawnGameObject;
    public Transform[] spawnPoints;
    private float timer;
    private bool nextWave = false;
    private int totalZombies = 10;
    public AudioClip openingAudio;

    public UnityEvent updateWave;
    public GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
        nextWave = true;
        updateWave = new UnityEvent();
        UI = GameObject.Find("UI");
    }

    // Update is called once per frame
    void Update()
    {
        if(nextWave)
        {
            GameInfo g = UI.GetComponent<GameInfo>();
            g.updateText(totalZombies);
            g.updateTotalZombies(totalZombies);
            nextWave = false;
            StartCoroutine(WaitOpening());
            StartCoroutine(WaitZombie());
        }
    }

    IEnumerator WaitZombie()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < totalZombies; i++)
        {
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(spawnGameObject, randomPoint.position, randomPoint.rotation);
            yield return new WaitForSeconds(2); 
        }
        yield return new WaitForSeconds(30);
        nextWave = true;
        totalZombies = totalZombies + 10;
    }

    IEnumerator WaitOpening()
    {
        for(int i = 0; i < 3; i++)
        {
            GetComponent<AudioSource>().PlayOneShot(openingAudio);
            yield return new WaitForSecondsRealtime(2);
        }
    }

    public int getTotalZombie()
    {
        return totalZombies;
    }
}
