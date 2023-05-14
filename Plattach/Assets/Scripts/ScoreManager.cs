using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int CurrentScore;
    public int LevelTwoScore;

    // Start is called before the first frame update

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        CurrentScore = 0;
        LevelTwoScore = 0;
}
    // Update is called once per frame
    void Update()
    {
        
    }
    public int UpdateCurrentScore(int score)
    {
        return CurrentScore += score;
        //LevelTwoScore = CurrentScore;
    }
    public int UpdateLevelTwoScore(int score)
    {
        return LevelTwoScore += score;
    }
}
