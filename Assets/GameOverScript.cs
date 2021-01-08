using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{

    private string menuScene = "Menu";

    // Start is called before the first frame update
    void Start()
    {
        //Scene menuScene = SceneManager.CreateScene("Menu");
        StartCoroutine(loadMenu());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator loadMenu()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(menuScene);
    }
}
