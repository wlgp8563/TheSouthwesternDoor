using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

    public GameObject scoreManagerObject;
    private ScoreManager scoreManager;
    private ScoreCounter score_counter = null;
    //public Text finalScoreText;
    public GUIStyle guistyle; // 폰트 스타일.;
    public int finalScore;

    //[SerializeField]
    //public Vector3 textPosition; // 텍스트의 위치를 조정하기 위한 변수
    //public float textSize; // 텍스트의 크기를 조정하기 위한 변수*/


    void Start()
    {
        scoreManagerObject = GameObject.Find("ScoreManager");
        this.scoreManager = scoreManagerObject.GetComponent<ScoreManager>();

        this.score_counter = this.gameObject.GetComponent<ScoreCounter>();

        scoreManager.UpdateLevelTwoScore(this.score_counter.GetTotalScore());
    }

    void Update() 
	{
        finalScore = scoreManager.UpdateLevelTwoScore(this.score_counter.GetTotalScore());

        //finalScoreText.text = "Final_Score: " + finalScore.ToString();

        //finalScoreText.transform.position = textPosition;

        // 텍스트 폰트 변경
        //finalScoreText.font = textFont;
        //finalScoreText.fontSize = Mathf.RoundToInt(textSize);
    }

    void OnGUI()
    {
        int x = 350;
        int y = 350;
        GUI.color = Color.black;
        this.print_value(x + 20, y, "Final_Score", finalScore);
    }
    public void print_value(int x, int y, string label, float value)
    {
        // label을 표시.
        GUI.Label(new Rect(x, y, 100, 20), label, guistyle);
        y += 30;
        // 다음 행에 value를 표시.
        GUI.Label(new Rect(x + 20, y, 100, 20), value.ToString(), guistyle);
    }
}

