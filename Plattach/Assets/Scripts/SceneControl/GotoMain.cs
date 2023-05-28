using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoMain : MonoBehaviour
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
        scoreManager.InitiateCurrentScore();
        scoreManager.InitiateCurrentMoves();

        StartCoroutine(GotoMainScene());
    }

    IEnumerator GotoMainScene()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("FirstLevel");
    }
}
