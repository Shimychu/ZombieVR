using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private int newScene;
    private AudioClip menu_select;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        Scene newScene = SceneManager.CreateScene("Game");
        //anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadNextScene()
    {
        StartCoroutine(menuAnimation());
    }

    IEnumerator menuAnimation()
    {
        GetComponent<AudioSource>().PlayOneShot(menu_select);
        //anim.Play("Fade out");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(newScene);
    }
}
