using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private int newScene;
    private AudioClip menu_select;

    // Start is called before the first frame update
    void Start()
    {
        Scene newScene = SceneManager.CreateScene("Game");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadNextScene()
    {
        GetComponent<AudioSource>().PlayOneShot(menu_select);
        SceneManager.LoadScene(newScene);
    }
}
