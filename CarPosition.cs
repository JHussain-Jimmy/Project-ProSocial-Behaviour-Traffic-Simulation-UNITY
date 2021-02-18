using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarPosition : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject driveInstruction;
    public GameObject driveInstruction2;
    private GameObject pointtargetcar;

    void OnEnable()
    {
        Time.timeScale = 1f;
        DestroyObject(driveInstruction, 2);
        pointtargetcar = GameObject.Find("arrowtoShowcar");
        pointtargetcar.SetActive(false);
    }

    void Update()
    {
        // replay current scene if outside street width
        if (transform.position.x < 95 || transform.position.x > 115)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        if ((transform.position.x >= 95 || transform.position.x <= 115) && transform.position.z >= 281)
        {
            mainmenu.SetActive(true);
            pointtargetcar.SetActive(true);
            Time.timeScale = 0f;
        }
        if ((transform.position.x >= 95 || transform.position.x <= 115) && transform.position.z >= 110)
        {
            driveInstruction2.SetActive(true);
            DestroyObject(driveInstruction2, 4);
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
