using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCounter : MonoBehaviour
{
	[SerializeField]
	private int limitMoves; // 최대 이동 가능 횟수
	private int leftMoves; // 현재 남은 이동 가능 횟수

	public int leftMoveScore;  //남은 이동 횟수를 점수로 환산 
	public GUIStyle guistyle; // 폰트 스타일.

	private BlockRoot block_root = null;

	void Start()
	{
		this.block_root = this.gameObject.GetComponent<BlockRoot>();
		this.leftMoves = this.limitMoves;
		this.guistyle.fontSize = 25;
	}

	void OnGUI()
	{
		int x = 10;
		int y = 330;
		GUI.color = Color.black;
		this.print_value(x + 20, y, "남은 이동 횟수", this.leftMoves);
	}

	public void print_value(int x, int y, string label, int value)
	{
		// label을 표시.
		GUI.Label(new Rect(x, y, 100, 20), label, guistyle);
		y += 25;
		// 다음 행에 value를 표시.
		GUI.Label(new Rect(x + 20, y, 100, 20), value.ToString(), guistyle);
		y += 25;
	}
	public void minusLeftMoves()
	{
		this.leftMoves--;
	}
	public void plusLeftMoves()
	{
		this.leftMoves++;
	}
	public int getLeftMoves() //남은 이동 가능 횟수를 리턴
	{
		return this.leftMoves;
	}
	public int leftMoveCount()                            //남은 이동 횟수에 10을 곱해서 점수로 만듦.
    {
		leftMoveScore = leftMoves * 10;
		return leftMoveScore;
    }
	public bool isLeftMovesZero()
	{
		
		if (this.leftMoves > 0)
			return false;
		// 현재 남은 이동 횟수가 0이면 
		return true;
	}
}
