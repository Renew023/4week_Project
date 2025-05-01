using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour 
{
    protected MiniGameManager miniGameManager;

    public virtual void Init(MiniGameManager minigame)
    {
        this.miniGameManager = minigame;
    }

    protected abstract UIState GetUIstate(); // ����ڴٰ� ���

    public void SetActive(UIState state)
    {
        this.gameObject.SetActive(GetUIstate() == state);
    }
}
