using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Image black;
    public Animator animator;

    public void NewGame(string scene)
    {
        Debug.Log("Change scene");
        SceneManager.LoadScene(scene);
    }

    public void ExitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void PlayGame(string scene)
    {
        Debug.Log("Change scene");
        //SceneManager.LoadScene(scene);
        StartCoroutine(Fading(scene));
    }
    IEnumerator Fading(string scene)
    {
        animator.SetTrigger("Fade");
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(scene);
        Timer.timer = 0;
    }
}
