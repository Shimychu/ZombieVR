using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameInfo : MonoBehaviour
{

    private int totalZombies;
    public TMPro.TextMeshProUGUI wave_text;
    public TMPro.TextMeshProUGUI zombie_remain_text;


    // Start is called before the first frame update
    void Start()
    {

        //Spawner.updateWave.AddListener(updateText);
        //wave_text = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        //zombie_remain_text = GetComponentInChildren<TMPro.TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        updateRemainingZombie();
    }

    public void updateText(int zombies)
    {
        //totalZombies = Spawner.getTotalZombie();
        if (zombies > 100)
            zombies = zombies / 100;
        else
            zombies = zombies / 10;
        wave_text.text = "Wave: " + zombies;
    }

    public void updateTotalZombies(int zombies)
    {
        totalZombies = zombies;
    }

    public void updateRemainingZombie()
    {
        zombie_remain_text.text = "Zombies: " + (totalZombies - zombie.getDeadZombie());
    }

}
