using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;

public class Recording : MonoBehaviour
{
    public GameObject platform;
    public float Distance; 
    public float distance = 0;
    public float Timetimer;
    public float time = 0;
    public float resetDis = 0;

    public List<float> timeRecord = new List<float>();
    public List<float> disRecord = new List<float>();

    public static List<string[]> rowData = new List<string[]>();

    public static string filePath = "Assets\\Resources\\";
    public static string fileName;

    // Start is called before the first frame update

    void Start()
    {
        for (int i = 0; i < Respawn.round; i++)
        {
            disRecord.Add(0);
        }

        /*Use this for initialization*/
        DisplayRound();

    }

    // Update is called once per frame

    void Update()
    {
        Distance = CalculateDistance.Distance_;
        Timetimer = Timer.timer;

        //Record Time for each round
        time = Timetimer;
        distance = Distance - resetDis;
    }

    void DisplayRound()
    {
        /*Creating first row of titles manually*/
        string[] rowDataTemp = new string[3];
        rowDataTemp[0] = "Round";
        rowDataTemp[1] = "Distance";
        rowDataTemp[2] = "Time";
        rowData.Add(rowDataTemp);
    }

    public static void Save()
    {
        fileName = filePath + PlayerInfo.UserData[0] + ".csv";
        StreamWriter writer = new StreamWriter(fileName);

        writer.WriteLine("Name: " +","+ PlayerInfo.UserData[0]);
        writer.WriteLine("Gender: "+"," + PlayerInfo.UserData[1] + "\n");
        for (int i = 0; i < Recording.rowData.Count; ++i)
        {
            writer.WriteLine(Recording.rowData[i][0] +
            "," + Recording.rowData[i][1] +
            "," + Recording.rowData[i][2]);
        }
        writer.Flush();
        writer.Close();
    }

}


