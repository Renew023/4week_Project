using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkDataManager : MonoBehaviour
{
    public static TalkDataManager instance;
    private List<string> talkList;
    private List<string> answerList;

    [SerializeField] private PlayerTalk playertalk;

    void Awake()
    {
        instance = this;
        Init();
    }

    void Init()
    {
		talkList.Add("환영합니다");
		talkList.Add("제 얘기를 들어주실래요");

		talkList.Add("감사합니다!");
		talkList.Add("에이 너무 하시네요..");

		answerList.Add("Ok");
		answerList.Add("No");
	}

    public string TalkData()
    {
        if (talkList.Count == 0)
            Init();

        return talkList[0];
    }

    public void Trigger(bool isShow)
    {
		if (answerList.Count == 0)
			Init();

		if (isShow)
            playertalk.Show(answerList.Count, answerList);
        else
            playertalk.Hide();
    }
}
