using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombBtn : MonoBehaviour
{
    public GameObject scoreManagerObject;
    private ScoreManager scoreManager;
    public Text numberOfBomb;
    public Text infoOfBomb;
    public bool usingBombItemState;
    public ColorBtn colorBtn;
    private void Start()
    {
        scoreManagerObject = GameObject.Find("ScoreManager");
        this.scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
        numberOfBomb.text = this.scoreManager.CurrentBombItem.ToString();
        usingBombItemState = false;
        infoOfBomb.text = "원하는 블럭을 \n삭제하는 아이템";

        if (this.scoreManager.CurrentBombItem == 0)
        {
            this.GetComponent<Button>().interactable = false;
        }
    }
    public void OnClick()
    {
        if(!colorBtn.usingColorItemState)
        {
            if (usingBombItemState)
            {
                infoOfBomb.text = "원하는 블럭을 \n삭제하는 아이템";
                usingBombItemState = false;
                Debug.Log("폭탄 버튼 취소");
                this.scoreManager.CurrentBombItem++;
                numberOfBomb.text = this.scoreManager.CurrentBombItem.ToString();

                Color color = this.GetComponent<Button>().GetComponent<Image>().color;
                color.a = 1.0f;
                this.GetComponent<Button>().GetComponent<Image>().color = color;
            }
            else
            {
                infoOfBomb.text = "삭제할 블럭을 선택하세요\n버튼 다시 눌러서 취소 가능";
                usingBombItemState = true;
                Debug.Log("폭탄 버튼 눌림: " + numberOfBomb.text);
                this.scoreManager.CurrentBombItem--;
                numberOfBomb.text = this.scoreManager.CurrentBombItem.ToString();

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
    public void UseBombItem()
    {
        usingBombItemState = false;
        infoOfBomb.text = "원하는 블럭을 \n삭제하는 아이템";
        Color color = this.GetComponent<Button>().GetComponent<Image>().color;
        color.a = 1.0f;
        this.GetComponent<Button>().GetComponent<Image>().color = color;
        if (this.scoreManager.CurrentBombItem == 0)
        {
            this.GetComponent<Button>().interactable = false;
        }
    }
}
