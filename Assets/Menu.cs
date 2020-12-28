using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private int newScene;

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
        
        SceneManager.LoadScene(newScene);
    }
}
