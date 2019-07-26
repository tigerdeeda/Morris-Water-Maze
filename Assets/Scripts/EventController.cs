using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventController : MonoBehaviour
{
    //Attribute for timer
    public static string TimeString;
    public Text Timetext;
    public static float timer = 60;
    private float minutes;
    private float seconds;

    public Transform player;
    public Transform spawnPoint;

    //Attribute for LoadScene
    public int scene;
    private bool stand = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        /*This part about calculating time*/
        timer += Time.deltaTime;
        minutes = Mathf.Floor(timer / 60);
        seconds = timer % 60;

        if (timer < 0 && stand == false)
        {
            timer = 30;
            player.transform.position = spawnPoint.transform.position;
            Debug.Log("Stand on Platform");
            stand = true;
        }
        else if (timer < 0 && stand == true)
        {
            SceneManager.LoadScene(scene);
        }
    }

    private IEnumerator UpdateCoroutine()
    {
        while (true)
        {
            Timetext.text = string.Format("{0:0}:{1:00}", minutes, seconds);
            TimeString = string.Format("{0:0}:{1:00}", minutes, seconds);
            yield return new WaitForSeconds(0.2f);
        }
    }


}
