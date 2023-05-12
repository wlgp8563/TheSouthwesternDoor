using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCounter : MonoBehaviour
{
	[SerializeField]
	private int InitYarn; // 최초 털실 숫자
	private int leftYarn; // 현재 남은 이동 가능 횟수

	public GUIStyle guistyle; // 폰트 스타일.

	private BlockRoot block_root = null;
	public int goalKeyBlock; //key block을 없앨 목표치

	void Start()
	{
		this.block_root = this.gameObject.GetComponent<BlockRoot>();
		this.leftYarn = this.InitYarn;
	}

    private void Update()
    {
		int keyCount = 0;
		int yarnCount = 0;
		foreach (BlockControl block in this.block_root.blocks)
		{
			if (block.isKeyBlock())
				keyCount++;
			if (block.isYarn())
				yarnCount++;
		}
		goalKeyBlock = keyCount;
		leftYarn = yarnCount;
	}

    void OnGUI()
	{
		int x = 20;
		int y = 50;
		GUI.color = Color.black;
		y += 90;
		this.print_value(x + 20, y, "남은 털실을 모두 없애세요, 남은 털실:", this.leftYarn);
		y += 30;
		if (this.block_root.KeyMode)
		{
			//남은 키 블럭 UI에 표시
			this.print_value(x + 20, y, "남은 키 블럭", this.goalKeyBlock);
			y += 30;
		}
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

	public bool isTargetClear()
	{
		if (this.leftYarn > 0)
			return false;
		if (this.block_root.KeyMode && this.goalKeyBlock>0)
			return false;
		return true;
	}
}
