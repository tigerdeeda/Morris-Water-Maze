using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;
using TMPro;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player; //Player (GameObject) attribute
    public GameObject playerObj;
    public int index; //index of spawn points
    public static int round; //input rounds of playing a game
    private int roundcheck; //attribute for comparing to round to end up a game
    public List<GameObject> freeSpawnPoints = new List<GameObject>(); //List of SpawnPoint in Hierachy
    public GameObject root; //Root is a EmptyObject which contains Timer script and Recording script for handling an event in the game

    public Image black; //Get an image
    public Animator animator; //Get an animator

    public TMP_Text roundCount; //Get Round Text
    private int numRound = 1; // number of round

    public AudioClip sound;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    public static float[] disRecord;

    /*First of all, declare an array of GameObject for gathering GameObject with tag 'Respawn' into an array, and then
      adds them into list names 'freeSpawnPoints' in the first frame*/
    void Start()
    {
        round = int.Parse(PlayerInfo.UserData[2]); //Set round from TextField
        GameObject[] respawns = GameObject.FindGameObjectsWithTag("Respawn");
        for (int i = 0; i < respawns.Length; i++) freeSpawnPoints.Add(respawns[i]);
        roundcheck = round - 1;
        roundCount.text = "Round: 1";
        Debug.Log(round); //Log of round
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.AddComponent<AudioSource>();
            source.clip = sound;
            source.playOnAwake = false;
            source.PlayOneShot(sound);

            if (root.GetComponent<Recording>() != null) /*First of all, check a script from root that enter to the a variable*/
            {
                root.GetComponent<Recording>().disRecord[index] = root.GetComponent<Recording>().distance; /*Then record the distance via disRecord in a Recording script*/
                                                                                                           /*Create rowDataTemp to gather the data*/
                string[] rowDataTemp = new string[3];
                rowDataTemp = new string[3];
                rowDataTemp[0] = (index + 1).ToString(); //round
                rowDataTemp[1] = root.GetComponent<Recording>().disRecord[index].ToString("####0.00"); //distance
                if (root.GetComponent<Timer>() != null)
                {
                    rowDataTemp[2] = root.GetComponent<Timer>().Timetext.text;
                }
                Recording.rowData.Add(rowDataTemp); //Send rowDataTemp to rowData in a Recording script
                                                    /*To gather the position of player to reset a distance of player*/
                root.GetComponent<Recording>().resetDis = root.GetComponent<Recording>().Distance + Vector3.Distance(freeSpawnPoints[index].GetComponent<Transform>().position, freeSpawnPoints[index + 1].GetComponent<Transform>().position);
                root.GetComponent<Recording>().distance = 0;
                Timer.timer = 0; //Set time to start a new round
                Vector3 pos = this.GetComponent<Transform>().position;

                Recording.Save(); //Record the output into .csv file

                if (roundcheck != 0)
                {
                    if (index == freeSpawnPoints.Count) return;
                    player.position = freeSpawnPoints[index++].GetComponent<Transform>().position;
                    roundcheck--;
                    numRound++;
                    roundCount.text = "Round: " + numRound;

                }
                else if (roundcheck == 0)
                {
                    StartCoroutine(Fading());
                    if (other.gameObject.tag == "Player")
                    {
                     
                        StartCoroutine(delay());
                        playerObj.SetActive(false);
                    }
                }

            }
        }
        else
        {
            Debug.Log("Over");
        }
    }

    IEnumerator Fading()
    {
        animator.SetTrigger("Fade");
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(4);
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(10);
    }

}