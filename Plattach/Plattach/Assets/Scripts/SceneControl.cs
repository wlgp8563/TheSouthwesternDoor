using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
	private ScoreCounter score_counter = null;
	private MoveCounter move_counter = null;
	private TargetCounter target_counter = null;
	public int level;
	public GameObject scoreManagerObject;
	private ScoreManager scoreManager;

	public enum STEP
	{
		NONE = -1, // 상태 정보 없음.
		PLAY = 0, // 플레이 중.
		LEVEL1CLEAR, // 클리어.
		LEVEL2CLEAR, // 클리어.
		NUM, // 상태가 몇 종류인지 나타낸다(=2).
		FAIL,
	};
	public STEP step = STEP.NONE; // 현재 상태.
	public STEP next_step = STEP.NONE; // 다음 상태.
	public float step_timer = 0.0f; // 경과 시간.
	private float clear_time = 0.0f; // 클리어 시간.
	public GUIStyle guistyle; // 폰트 스타일.

	[SerializeField]
	private int initialGap;
	[SerializeField]
	private int changedGap;
	[SerializeField]
	private int row;
	[SerializeField]
	private int column;
	[SerializeField]
	private int timeLimit;
	[SerializeField]
	private float horizontalSplitMoves; //남은 이동 횟수가 몇이여야 horizontalSplit 할건지?
	[SerializeField]
	private float verticalSplitMoves; //남은 이동 횟수가 verticalSplit 할건지?

	private BlockRoot block_root = null;
	void Start()
	{
		// BlockRoot 스크립트를 취득.
		this.block_root = this.gameObject.GetComponent<BlockRoot>();

		this.block_root.create();

		// BlockRoot 스크립트의 initialSetUp()을 호출한다.
		this.block_root.initialSetUp(initialGap, initialGap, row, column);

		// ScoreCounter를 가져온다.
		this.score_counter = this.gameObject.GetComponent<ScoreCounter>();

		// MoveCounter를 가져온다.
		this.move_counter = this.gameObject.GetComponent<MoveCounter>();
		
		// MoveCounter를 가져온다.
		this.target_counter = this.gameObject.GetComponent<TargetCounter>();

		//socreManger을 찾아서 가져온다.
		scoreManagerObject = GameObject.Find("ScoreManager");
		this.scoreManager = scoreManagerObject.GetComponent<ScoreManager>();

		this.next_step = STEP.PLAY; // 다음 상태를 '플레이 중'으로.
		this.guistyle.fontSize = 24; // 폰트 크기를 24로.
	}

	void Update()
	{
		this.step_timer += Time.deltaTime;

		switch (this.step)
		{
			case STEP.LEVEL1CLEAR:
				if (Input.GetMouseButtonDown(0))
				{
					SceneManager.LoadScene("SecondLevel");
				}
				break;

			case STEP.LEVEL2CLEAR:
				if (Input.GetMouseButtonDown(0))
				{
					SceneManager.LoadScene("ClearScene");
				}
				break;

			case STEP.FAIL:
				if (Input.GetMouseButtonDown(0))
				{
					SceneManager.LoadScene("FailScene");
				}
				break;
		}

		// 상태변화대기-----.
		if (this.next_step == STEP.NONE)
		{
			switch (this.step)
			{
				case STEP.PLAY:
					if (this.move_counter.getMoves() == horizontalSplitMoves)
					{
						block_root.horizontalSplitSetUp(changedGap);
					}
					if (this.move_counter.getMoves() == verticalSplitMoves)
					{
						block_root.verticalSplitSetUp(changedGap);
					}
					break;
			}
		}

		// 상태가 변화하면------.
		while (this.next_step != STEP.NONE)
		{
			this.step = this.next_step;
			this.next_step = STEP.NONE;
			switch (this.step)
			{
				case STEP.LEVEL1CLEAR:
				case STEP.LEVEL2CLEAR:
					// block_root를 정지.
					this.block_root.enabled = false;
					// 경과 시간을 클리어 시간으로 설정.
					this.clear_time = this.step_timer;
					this.step_timer = 0.0f;
					break;
				case STEP.FAIL:
					this.block_root.enabled = false;
					this.step_timer = 0.0f;
					break;
			}
		}
	}

	public void checkClearOrOver()//발화가 모두 끝나면 실행되는 함수
	{
		// 상태변화대기-----.
		if (this.next_step == STEP.NONE)
		{
			switch (this.step)
			{
				case STEP.PLAY:
					// 클리어 조건을 만족하면.
					if (this.target_counter.isTargetClear())
					{
						if (level == 1)
						{
							scoreManager.UpdateCurrentScore(this.score_counter.GetTotalScore());
							scoreManager.UpdateCurrentMoves(this.move_counter.getLeftMoves());
							this.next_step = STEP.LEVEL1CLEAR; // 클리어 상태로 이행.
						}
						else if (level == 2)
						{
							scoreManager.UpdateCurrentScore(this.score_counter.GetTotalScore());
							scoreManager.UpdateCurrentMoves(this.move_counter.getLeftMoves());
							this.next_step = STEP.LEVEL2CLEAR; // 클리어 상태로 이행.
						}
					}
					if(this.move_counter.isLeftMovesZero())
                    {
						Invoke("checkfail", 1f);
					}
					break;
			}
		}
	}

	void checkfail()
    {
		if (!this.target_counter.isTargetClear())
		{
			scoreManager.UpdateCurrentScore(this.score_counter.GetTotalScore());
			scoreManager.UpdateCurrentMoves(this.move_counter.getLeftMoves());
			this.next_step = STEP.FAIL;
		}
	}

	void OnGUI()
	{
		switch (this.step)
		{
			case STEP.PLAY:
				GUI.color = Color.black;
				// 경과 시간을 표시.
				GUI.Label(new Rect(30.0f, 10.0f, 200.0f, 20.0f),
						  "경과 시간" + Mathf.CeilToInt(this.step_timer).ToString() + "초",
						  guistyle);
				GUI.color = Color.white;
				GUI.color = Color.black;
				break;
			case STEP.LEVEL1CLEAR:
			case STEP.LEVEL2CLEAR:
				GUI.color = Color.black;
				// 「☆클리어-！☆」라는 문자열을 표시.
				GUI.Label(new Rect(
					Screen.width / 2.0f - 80.0f, 20.0f, 200.0f, 20.0f),
						  "☆클리어-！☆", guistyle);
				// 클리어 시간을 표시.
				GUI.Label(new Rect(
					Screen.width / 2.0f - 80.0f, 40.0f, 200.0f, 20.0f),
						  "클리어 시간" + Mathf.CeilToInt(this.clear_time).ToString() +
						  "초", guistyle);
				GUI.color = Color.white;
				break;
			case STEP.FAIL:
				GUI.color = Color.black;
				GUI.Label(new Rect(
					Screen.width / 2.0f - 80.0f, 20.0f, 200.0f, 20.0f),
						  "실패 ㅠ.ㅠ", guistyle);
				GUI.color = Color.white;
				break;
		}
	}


}