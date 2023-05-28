using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQuit : MonoBehaviour
{
    public void OnClick()
    {
        StartCoroutine(SceneQuit());
        
    }

    IEnumerator SceneQuit()
    {
        yield return new WaitForSeconds(1.0f);
        Application.Quit();
    }
}
