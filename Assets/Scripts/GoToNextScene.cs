using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToNextScene : MonoBehaviour
{
    // This method for triggering when the player reaches the cyclinder.
    public int scene;
    public Image black;
    public Animator animator;
    public AudioClip sound;

    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            gameObject.AddComponent<AudioSource>();
            source.clip = sound;
            source.playOnAwake = false;
            source.PlayOneShot(sound);

            Debug.Log("Change scene");
            //SceneManager.LoadScene(scene);
            StartCoroutine(Fading());
        }
    }
    
    IEnumerator Fading()
    {
        animator.SetTrigger("Fade");
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(scene);
        Timer.timer = 0;
    }
}
