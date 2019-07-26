using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInfo : MonoBehaviour
{
    public TMP_InputField name;
    public Dropdown gender;
    public TMP_InputField round;

    public static string[] UserData = new string[3];
    public static List<string> genders = new List<string> { "Male", "Female" };

    public void test()
    {
        int num = gender.value;
        UserData[0] = name.text;
        UserData[1] = genders[num];
        UserData[2] = round.text;
    }
    


}
