using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public static string TimeString;
    public TMP_Text Timetext;
    public static float timer;
    private float minutes;
    private float seconds;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateCoroutine());
    }

    // Update is called once per frame
   void Update()
   {
        timer += Time.deltaTime;
        minutes = Mathf.Floor(timer / 60);
        seconds = timer % 60;
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
