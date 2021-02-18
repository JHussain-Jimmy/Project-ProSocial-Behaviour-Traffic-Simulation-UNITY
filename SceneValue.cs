using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class SceneValue : MonoBehaviour
{
    static public bool[] scenevalue = new bool[7];
    static public int sceneplayed;

    public void Start ()
    { 
        sceneplayed = SceneManager.GetActiveScene().buildIndex;
       // if (scenevalue [scenevalue.Length-2] == true)
       //CreateText();
    }
    public void PlayGame()
    {
        //sceneplayed = SceneManager.GetActiveScene().buildIndex;
        // It is for first time click from UI menu
        scenevalue[sceneplayed] = true;
        SceneManager.LoadScene("LoadingScene");
    }
    static public void CreateText()
    {
        string[] question = new string[] { "\n",
                                         "SIMPLE YIELD with Conventional Car",
                                         "SIMPLE YIELD with Autonomous Car", 
                                         "PARKING-SPOT-Yield with Conventional Car",
                                         "PARKING-SPOT-Yield with Autonomous Car",
                                         "Pass-or-Wait with Conventional Car",
                                         "Pass-or-Wait with Autonomous Car"};
        string answer;
        string path = Application.dataPath + "/Log File.txt";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "ProSocial Experiment User Data:\n\n");
        }
        string time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ff");
        File.AppendAllText(path, "This study data was collected on: " + time + "\n");
        for (int i=1; i < scenevalue.Length; i++)
        { 
        question[i] = question[i] + " - Scene Number: " + i + "\t";
        if (LevelLoader.answer[i])
                answer = "Decision: " + "Yields" + "\n";
        else
                answer = "Decision: " + "Doesn't Yield" + "\n";
        File.AppendAllText(path, question[i] + "\t\t\t" + answer);
        }
        File.AppendAllText(path, "\n");
    }

}
