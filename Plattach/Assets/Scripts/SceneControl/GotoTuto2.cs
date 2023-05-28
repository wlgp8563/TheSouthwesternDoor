using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoTuto2 : MonoBehaviour
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
        StartCoroutine(GotoTutorialScene2());
    }

    IEnumerator GotoTutorialScene2()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Tutorial2");
    }
}
