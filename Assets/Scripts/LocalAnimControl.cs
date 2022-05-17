using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalAnimControl : MonoBehaviour
{

    private List<string> animFBXList = new List<string>();
    private List<string> animXsensList = new List<string>();

    private List<string> lhopList = new List<string>();
    private List<string> lungeList = new List<string>();
    private List<string> vertJumpList = new List<string>();


    private List<string> currAnimList = new List<string>();

    public static GameObject character;
    private Animator animator;
    private int currAnimIndex;
    private string currAnimName;

    // Start is called before the first frame update
    void Start()
    {

        lhopList.Add("lhop1");
        lhopList.Add("lhop2");
        lhopList.Add("lhop3");

        lungeList.Add("lunge1");
        lungeList.Add("lunge2");
        lungeList.Add("lunge3");

        vertJumpList.Add("vertJump1");
        vertJumpList.Add("vertJump2");
        vertJumpList.Add("vertJump3");

        currAnimList = lhopList;

        currAnimIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (LocalModeSelection.modeSelected != "VideoMode")
        {
            if (LocalTaskSelection.taskSelectedFlag == true)
            {
                if (LocalTaskSelection.taskSelected == "lhop")
                {
                    currAnimList = lhopList;
                }

                if (LocalTaskSelection.taskSelected == "lunge")
                {
                    currAnimList = lungeList;
                }

                if (LocalTaskSelection.taskSelected == "vertJump")
                {
                    currAnimList = vertJumpList;
                }

                LocalTaskSelection.taskSelectedFlag = false;
            }

            if (LocalTaskSelection.taskSelected != "")
            {
                animator = character.GetComponent<Animator>();

                GameObject.Find("AnimationName").GetComponent<UnityEngine.UI.Text>().text = currAnimList[currAnimIndex];
            }
        }

        currAnimName = LocalModeSelection.modeSelected + "/" + LocalTaskSelection.taskSelected;
        if (LocalTaskSelection.taskSelected != "")
        GameObject.Find("TaskOnDisplay").GetComponent<UnityEngine.UI.Text>().text = currAnimName;
    }

    public void PlayAnim()
    {
        if (LocalModeSelection.modeSelected != "VideoMode")
        {
            if (currAnimIndex == currAnimList.Count)
            {
                currAnimIndex--;
            }
            animator.Play(currAnimList[currAnimIndex], 0, 0f);
        }
    }

    public void PlayAnimNext()
    {
        if (LocalModeSelection.modeSelected != "VideoMode")
        {
            currAnimIndex++;
            if (currAnimIndex != currAnimList.Count)
                if (currAnimIndex < currAnimList.Count)
                {
                    animator.Play(currAnimList[currAnimIndex], 0, 0f);

                }

            if (currAnimIndex == currAnimList.Count)
            {
                currAnimIndex--;
            }
        }

    }

    public void PlayAnimPrevious()
    {
        if (LocalModeSelection.modeSelected != "VideoMode")
        {
            if (currAnimIndex > 0)
                animator.Play(currAnimList[currAnimIndex--], 0, 0f);
        }
    }

    public void CurrAnimIndexReset()
    {
        currAnimIndex = 0;
    }
}
