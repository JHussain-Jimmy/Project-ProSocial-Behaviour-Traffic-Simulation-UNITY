using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarPositionScene2 : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject driveInstruction;
    public GameObject driveInstruction2;
    public GameObject taskInstuction;
    private GameObject pointtargetcar;

    void OnEnable()
    {
        Time.timeScale = 1f;
        DestroyObject(driveInstruction, 3);
        pointtargetcar = GameObject.Find("arrowtoShowcar");
        pointtargetcar.SetActive(false);
    }

    void Update()
    {
        
         if (transform.position.x >= 1107)
         {
             mainmenu.SetActive(true);
             pointtargetcar.SetActive(true);
             Time.timeScale = 0f;
         }

        if (transform.position.x >= 1003 && transform.position.x < 1106)
        {
            taskInstuction.SetActive(true);
            DestroyObject(taskInstuction, 4);
        }

        if (transform.position.x >= 962 && transform.position.x <= 967)
        {
            driveInstruction2.SetActive(true);
            DestroyObject(driveInstruction2, 3);
        }

        if (transform.position.z < 140 || transform.position.z > 155)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
}

    public void cont()
    {
        SceneValue.scenevalue[SceneManager.GetActiveScene().buildIndex] = true;
        SceneValue.sceneplayed = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("LoadingScene");
    }

    public void replay()
    {
        Application.LoadLevel(Application.loadedLevel);
    }   
}
