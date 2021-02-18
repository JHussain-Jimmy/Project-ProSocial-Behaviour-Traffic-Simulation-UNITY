using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarPositionScene3 : MonoBehaviour
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
        
         if (transform.position.x >= 910)
         {
             mainmenu.SetActive(true);
             pointtargetcar.SetActive(true);
             Time.timeScale = 0f;
         }

        if (transform.position.x >= 810)
        {
            driveInstruction2.SetActive(true);
            DestroyObject(driveInstruction2, 2);
        }

        if (transform.position.z < -9.7 || transform.position.z > 9.7)
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
