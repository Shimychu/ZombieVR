using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameInfo : MonoBehaviour
{

    private int totalZombies;
    private TMPro.TextMeshProUGUI m_text;


    // Start is called before the first frame update
    void Start()
    {
        //Spawner.updateWave.AddListener(updateText);
        m_text = GetComponentInChildren<TMPro.TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateText(int zombies)
    {
        //totalZombies = Spawner.getTotalZombie();
        if (zombies > 100)
            zombies = zombies / 100;
        else
            zombies = zombies / 10;
        m_text.text = "Wave: " + zombies;
    }

}
