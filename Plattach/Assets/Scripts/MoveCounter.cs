using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCounter : MonoBehaviour
{
	[SerializeField]
	private int limitMoves; // 최대 이동 가능 횟수
	public int leftMoves; // 현재 남은 이동 가능 횟수

	public GUIStyle guistyle; // 폰트 스타일.

	private BlockRoot block_root = null;
	public GameObject scoreManagerObject;
	private ScoreManager scoreManager;
	private int moves;
	void Start()
	{
		scoreManagerObject = GameObject.Find("ScoreManager");
		this.scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
		this.block_root = this.gameObject.GetComponent<BlockRoot>();
		this.leftMoves = this.limitMoves + this.scoreManager.GetCurrentMoves();
		moves = 0;
		this.guistyle.fontSize = 30;
	}

	void OnGUI()
	{
		this.guistyle.fontSize = 30;
		int x = 0;
		int y = 390;
		GUI.color = Color.red;
		this.print_value(x + 140, y, "남은 이동 횟수: ", this.leftMoves);
	}

	public void print_value(int x, int y, string label, int value)
	{
		// label을 표시.
		GUI.Label(new Rect(x, y, 100, 20), label, guistyle);
		//y += 30;
		// 다음 행에 value를 표시.
		GUI.Label(new Rect(x + 170, y, 100, 20), value.ToString(), guistyle);
		y += 30;
	}
	public void minusLeftMoves()
	{
		this.leftMoves--;
		moves++;
	}
	public void plusLeftMoves(int plusMove)
	{
		this.leftMoves += plusMove;
	}
	public int getLeftMoves() //남은 이동 가능 횟수를 리턴
	{
		return this.leftMoves;
	}
	public int getMoves() //현재 라운드에서 이 함수가 출력한 시점 까지의 총 이동한 횟수를 리턴
	{
		return moves;
	}

	public bool isLeftMovesZero()
	{
		
		if (this.leftMoves > 0)
			return false;
		// 현재 남은 이동 횟수가 0이면 
		return true;
	}
}
