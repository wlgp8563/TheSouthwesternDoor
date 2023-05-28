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
    public int finalLeftMoves;
    public int realFinalScore;

    //[SerializeField]
    //public Vector3 textPosition; // 텍스트의 위치를 조정하기 위한 변수
    //public float textSize; // 텍스트의 크기를 조정하기 위한 변수*/


    void Start()
    {
        scoreManagerObject = GameObject.Find("ScoreManager");
        this.scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
        finalScore = scoreManager.GetCurrentScore();
        finalLeftMoves = scoreManager.GetCurrentMoves();
        realFinalScore = finalScore + finalLeftMoves * 1000; //여기서 진짜 최종 점수 합산
    }

    void Update() 
	{

        //finalScoreText.text = "Final_Score: " + finalScore.ToString();

        //finalScoreText.transform.position = textPosition;

        // 텍스트 폰트 변경
        //finalScoreText.font = textFont;
        //finalScoreText.fontSize = Mathf.RoundToInt(textSize);
    }

    void OnGUI()
    {
        int x = 1300 / 2;
        int y = 600 / 2;
        GUI.color = Color.black;
        this.print_value(x, y, "1, 2 라운드 합산 점수", finalScore);
        y += 60;
        this.print_value(x, y, "남은 이동 횟수", finalLeftMoves);
        y += 60;
        this.print_value(x, y, "최종 합산 점수", realFinalScore);
    }
    public void print_value(int x, int y, string label, float value)
    {
        // label을 표시.
        GUI.Label(new Rect(x, y, 100, 20), label, guistyle);
        // 다음 행에 value를 표시.
        GUI.Label(new Rect(x + 250, y, 100, 20), value.ToString(), guistyle);
    }
}

