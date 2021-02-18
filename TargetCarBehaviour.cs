using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCarBehaviour : MonoBehaviour
{
    public GameObject carlights;
    
    void Start()
    {
        //this.GetComponent<Renderer>().enabled = true;
        carlights = GameObject.Find("otherCarzLights");
        InvokeRepeating("Blinking", 4.0f, 1.0f);
 
    }

    void Blinking()
    {
        StartCoroutine(BlinkCoroutine());
    }
    void Update()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        //StartCoroutine(ExampleCoroutine());

    }

    IEnumerator BlinkCoroutine()
    {
        carlights.SetActive(false);

        //yield on a new YieldInstruction that waits for .5 seconds.
        yield return new WaitForSeconds(0.5f);

        //After we have waited 5 seconds print the time again.
        carlights.SetActive(true);
    }
}