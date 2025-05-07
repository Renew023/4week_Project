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
		talkList.Add("ȯ���մϴ�");
		talkList.Add("�� ��⸦ ����ֽǷ���");

		talkList.Add("�����մϴ�!");
		talkList.Add("���� �ʹ� �Ͻó׿�..");

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
