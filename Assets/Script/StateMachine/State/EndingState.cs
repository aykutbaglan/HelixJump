using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class EndingState : State
{
    public Button button;

    private void OnEnable()
    {
        button.onClick.AddListener(OnButtonClicked);
    }
    private void OnDisable()
    {
        button.onClick.RemoveListener(OnButtonClicked);
    }
    public override void OnEnter()
    {
        base.OnEnter();
        base.ballController.RBActiveControl(false);
    }
    public override void OnExit()
    {
        base.OnExit();
    }
    public abstract void OnButtonClicked();
}
