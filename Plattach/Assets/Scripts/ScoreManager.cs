using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private int CurrentScore;
    [SerializeField]
    private int CurrentMoves;

    // Start is called before the first frame update

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("TitleScene");
    }
    void Start()
    {
        CurrentScore = 0;
        CurrentMoves = 0;
}
    // Update is called once per frame
    void Update()
    {
        
    }
    public int UpdateCurrentScore(int score)
    {
        CurrentScore = score;
        return CurrentScore;
        //LevelTwoScore = CurrentScore;
    }
    public int GetCurrentScore()
    {
        return CurrentScore;
    }
    public void InitiateCurrentScore()
    {
        CurrentScore = 0;
    }

    public int UpdateCurrentMoves(int moves)
    {
        CurrentMoves = moves;
        return CurrentMoves;
        //LevelTwoScore = CurrentScore;
    }
    public int GetCurrentMoves()
    {
        return CurrentMoves;
    }
    public void InitiateCurrentMoves()
    {
        CurrentMoves = 0;
    }
}
