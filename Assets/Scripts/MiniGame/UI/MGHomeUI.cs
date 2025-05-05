using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MGHomeUI : MGBaseUI
{

	public override void Init(MGUIManager uiManager)
	{
		base.Init(uiManager);
	}

	public void Update()
	{
	}

	public void OnClickStart()
	{
		uiManager.OnClickStart();
	}

	protected override MGUIState GetUIState()
	{
		return MGUIState.Home;
	}
}