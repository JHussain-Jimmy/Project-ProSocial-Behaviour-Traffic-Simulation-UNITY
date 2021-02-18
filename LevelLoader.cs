using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject Question0;
    public GameObject Question1;
    public GameObject Question2;
    public GameObject Question3;
    public GameObject Question4;
    public GameObject Question5;
    public GameObject loadingScreen;
    public Slider slider;
    public Text ProgressText;
    private int sceneIndex;
    static public bool[] answer = new bool[7];

    public void Start()
    {
        Time.timeScale = 1f;
        SceneValue.scenevalue[SceneValue.sceneplayed] = true;
        if (SceneValue.sceneplayed == 0)
        {
            if (! allScenesPlayed() )
            {
                RunScene();
            }
            else
                Question0.SetActive(true);
        }
        else if (SceneValue.sceneplayed == 1)
        {
            Question1.SetActive(true);
        }
        else if (SceneValue.sceneplayed == 2)
        {
            Question2.SetActive(true);
        }
        else if (SceneValue.sceneplayed == 3)
        {
            Question3.SetActive(true);
        }
        else if (SceneValue.sceneplayed == 4)
        {
            Question4.SetActive(true);
        }
        else if (SceneValue.sceneplayed == 5 || SceneValue.sceneplayed == 6)
        {
            Question5.SetActive(true);
        }
    }

    public void answeredyes()
    {
        answer[SceneValue.sceneplayed] = true;
        RunScene();
    }
    public void answeredno()
    {
        answer[SceneValue.sceneplayed] = false;
        RunScene();
    }

    public void RunScene()
    {
        Question1.SetActive(false);
        Question2.SetActive(false);
        Question3.SetActive(false);
        Question4.SetActive(false);
        Question5.SetActive(false);
        if (!allScenesPlayed())
        {
            sceneIndex = randomizeNextScene();
            StartCoroutine(LoadAsynchronously(sceneIndex));
        }
        else
        {
            SceneValue.CreateText();
            Question0.SetActive(true);
        }
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progress = Mathf.Round(progress * 100f) / 100f;
            ProgressText.text = progress * 100f + "%";
            yield return null;
        }
    }

    public void overnowprint()
    {

        SceneManager.LoadScene(0);
    }

    public bool allScenesPlayed()
    {
      
      for (int i = 0; i < SceneValue.scenevalue.Length; i++)
        {
           if (SceneValue.scenevalue[i] == false)
                return false;
        }
        return true;
    }

    public int randomizeNextScene()
    {
         int unplayedScenes = 0;
         int [] tempscenesIndexes = new int[SceneValue.scenevalue.Length];
         for (int i = 0; i < SceneValue.scenevalue.Length; i++)
         {
             if (SceneValue.scenevalue[i] == false)
             {
                 tempscenesIndexes[unplayedScenes] = i;
                 unplayedScenes++;
             }
         }
         int [] unplayedscenesIndexes = new int[unplayedScenes];

         for (int j = 0; j < unplayedScenes; j++)
         {
             unplayedscenesIndexes[j] = tempscenesIndexes[j];
         }
         sceneIndex = Random.Range(unplayedscenesIndexes[0], unplayedscenesIndexes[unplayedScenes - 1] + 1);

         if (unplayedScenes > 2)
         {
             if (SceneValue.sceneplayed % 2 == 0)
             {
                 if (sceneIndex == SceneValue.sceneplayed - 1)
                     randomizeNextScene();
             }
             else
             {
                 if (sceneIndex == SceneValue.sceneplayed + 1)
                     randomizeNextScene();
             }
         }
        if (sceneIndex == SceneValue.sceneplayed)
            randomizeNextScene();
        return sceneIndex;
    }
}
