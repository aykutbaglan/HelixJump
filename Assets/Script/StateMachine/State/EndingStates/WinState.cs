using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : EndingState
{
    public override void OnButtonClicked()
    {
        GameManager.NextButtonSceenLoad();
    }
}