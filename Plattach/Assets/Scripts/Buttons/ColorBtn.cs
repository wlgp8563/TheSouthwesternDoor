using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorBtn : MonoBehaviour
{
    public GameObject scoreManagerObject;
    private ScoreManager scoreManager;
    public Text numberOfColor;
    public Text infoOfColor;
    public bool usingColorItemState;
    public BombBtn bombBtn;

    // Start is called before the first frame update
    void Start()
    {
        scoreManagerObject = GameObject.Find("ScoreManager");
        this.scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
        numberOfColor.text = this.scoreManager.CurrentColorItem.ToString();
        usingColorItemState = false;
        infoOfColor.text = "원하는 블럭의 색을 \n바꾸는 아이템";

        if (this.scoreManager.CurrentColorItem == 0)
        {
            this.GetComponent<Button>().interactable = false;
        }
    }

    public void OnClick()
    {
        if(!bombBtn.usingBombItemState)
        {
            if (usingColorItemState)
            {
                infoOfColor.text = "원하는 블럭의 색을 \n바꾸는 아이템";
                usingColorItemState = false;
                Debug.Log("컬러 버튼 취소");
                this.scoreManager.CurrentColorItem++;
                numberOfColor.text = this.scoreManager.CurrentColorItem.ToString();

                Color color = this.GetComponent<Button>().GetComponent<Image>().color;
                color.a = 1.0f;
                this.GetComponent<Button>().GetComponent<Image>().color = color;
            }
            else
            {
                infoOfColor.text = "원하는 블럭을 주변 블럭과 swap하면 색이 변해요\n버튼 다시 눌러서 취소 가능";
                usingColorItemState = true;
                Debug.Log("컬러 버튼 눌림: " + numberOfColor.text);
                this.scoreManager.CurrentColorItem--;
                numberOfColor.text = this.scoreManager.CurrentColorItem.ToString();

                Color color = this.GetComponent<Button>().GetComponent<Image>().color;
                color.a = 0.5f;
                this.GetComponent<Button>().GetComponent<Image>().color = color;

                /*if (this.scoreManager.CurrentBombItem == 0)
                {
                    this.GetComponent<Button>().interactable = false;
                }*/
            }
        }
    }

    public void UseColorItem()
    {
        usingColorItemState = false;
        infoOfColor.text = "원하는 블럭의 색을 \n바꾸는 아이템";
        Color color = this.GetComponent<Button>().GetComponent<Image>().color;
        color.a = 1.0f;
        this.GetComponent<Button>().GetComponent<Image>().color = color;
        if (this.scoreManager.CurrentColorItem == 0)
        {
            this.GetComponent<Button>().interactable = false;
        }
    }
}
