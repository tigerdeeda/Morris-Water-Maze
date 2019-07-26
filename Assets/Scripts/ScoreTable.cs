using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreTable : MonoBehaviour
{
    public Text UserName;
    public Text Gender;
    public Text numRound;
    public Text numDis;
    public Text numTime;
    //private int roundTab;


    // Start is called before the first frame update
    void Start()
    {
       
        UserName.text = "Name: "+PlayerInfo.UserData[0];
        Gender.text = "Gender: "+ PlayerInfo.UserData[1]; 
        numRound.text = "";
        numDis.text = "";
        numTime.text = "";

        for (int i = 0; i < Recording.rowData.Count; i++)
        {
            numRound.text += Recording.rowData[i][0] + "\n";
            numDis.text += Recording.rowData[i][1] + "\n";
            numTime.text += Recording.rowData[i][2]+ "\n";
        }
    }

    void Update()
    {
        Delete();
    }

    void Delete()
    {
        Recording.rowData.Clear();
        CalculateDistance.Distance_ = 0;
    }

}
