using UnityEngine;
using System.Collections;

public class ScoreCounter : MonoBehaviour
{

	public struct Count
	{ // 점수 관리용 구조체.
		public int ignite; // 발화 수.
		public int score; // 점수.
		public int total_score; // 합계 점수.
		public int fever_score;  //피버 타임 체크 스코어
	};
	public Count last; // 마지막(이번) 점수.
	public Count best; // 최고 점수.
	public static int QUOTA_SCORE = 5000; // 클리어에 필요한 점수.
	public int feverTimeCount = 0;
	//public bool isFever = false;
	public GUIStyle guistyle; // 폰트 스타일.
	private SceneControl count_root = null;

	[SerializeField]
	private int fevergage;

	public int goalKeyBlock; //key block을 없앨 목표치

	private BlockRoot block_root = null;
	
	void Start()
	{
		this.block_root = this.gameObject.GetComponent<BlockRoot>();
		this.count_root = this.gameObject.GetComponent<SceneControl>();
		this.last.ignite = 0;
		this.last.score = 0;
		this.last.total_score = 0;
		//this.last.fever_score = 0;
		this.guistyle.fontSize = 16;
	}

	void OnGUI()
	{
		Debug.Log(this.last.fever_score);
		int x = 20;
		int y = 50;
		GUI.color = Color.black;
		this.print_value(x + 20, y, "발화 카운트", this.last.ignite);
		y += 30;
		this.print_value(x + 20, y, "가산 스코어", this.last.score);
		y += 30;
		this.print_value(x + 20, y, "합계 스코어", this.last.total_score);
		y += 30;

		if (!this.block_root.FreeSwapMode)
		{
			//남은 키 블럭 UI에 표시
			this.print_value(x + 20, y, "남은 키 블럭", this.goalKeyBlock);
			y += 30;
		}
		this.print_value(x + 20, y, "피버타임게이지", this.last.fever_score);
	}
	public void print_value(int x, int y, string label, int value)
	{
		// label을 표시.
		GUI.Label(new Rect(x, y, 100, 20), label, guistyle);
		y += 15;
		// 다음 행에 value를 표시.
		GUI.Label(new Rect(x + 20, y, 100, 20), value.ToString(), guistyle);
		y += 15;
	}
	public void addIgniteCount(int count)
	{
		this.last.ignite += count; // 발화 수에 count를 가산.
		this.update_score(); // 점수를 계산.
	}
	public void clearIgniteCount()
	{
		this.last.ignite = 0; // 발화 횟수를 리셋.
	}
	public void minusGoalKeyCount()
	{
		this.goalKeyBlock -= 1; // 삭제해야할 key block의 목표치를 감소시킴
	}
	
	public void update_score()
	{
		this.last.score = this.last.ignite * 10; // 스코어를 갱신.
	}


	public void Fever_time()
	{
		//int fever_multiplier = 2; // 스코어 배수할 크기
		//float fever_duration = 5.0f; // 피버 타임 지속 시간(초)

		if (fevergage * (feverTimeCount + 1) <= this.last.total_score)
		{
			this.last.fever_score = 0;
			//feverUpdateScore();
			//isFever = true;
			//update_score();
			StartCoroutine(FeverCoroutine());
			feverTimeCount++;
		}
		//isFever = false;
	}

	IEnumerator FeverCoroutine()
	{
		Debug.Log("피버코루틴");
		int originalScore = this.last.total_score;
		// 스코어 배수를 적용하고 duration 동안 기다린 후 다시 원래 스코어로 돌아옴
		
		this.last.total_score = originalScore + (this.last.score * 2);
		this.last.fever_score += this.last.score;
		yield return new WaitForSeconds(5.0f);
	}

	public void updateTotalScore()
	{
		this.last.total_score += this.last.score; // 합계 스코어를 갱신.
		this.last.fever_score = this.last.total_score - (fevergage * feverTimeCount);
		Fever_time();
	}
	public bool isGameClear()
	{
		bool is_clear = false;
		// 현재 합계 스코어가 클리어 기준보다 크다면.
		if (this.last.total_score > QUOTA_SCORE)
		{
			is_clear = true;
		}
		return (is_clear);
	}
}