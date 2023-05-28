using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoTitle : MonoBehaviour
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

        StartCoroutine(GotoTitleScene());
        
    }

    IEnumerator GotoTitleScene()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("TitleScene");
    }
}
