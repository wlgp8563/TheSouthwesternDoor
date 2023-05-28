using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoTuto1 : MonoBehaviour
{
    public GameObject scoreManagerObject;
    private ScoreManager scoreManager;
    private void Start()
    {
        scoreManagerObject = GameObject.Find("ScoreManager");
        this.scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
    }
    public void OnClick()
    {
        StartCoroutine(GotoTutorialScene1());
    }

    IEnumerator GotoTutorialScene1()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Tutorial1");
    }
}
