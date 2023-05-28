using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoTuto3 : MonoBehaviour
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
        StartCoroutine(GotoTutorialScene3());
    }

    IEnumerator GotoTutorialScene3()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Tutorial3");
    }
}
