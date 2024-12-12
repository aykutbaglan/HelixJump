using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class EndingState : State
{
    public Button button;
    [SerializeField] private InputController inputController;
    [SerializeField] private WinState winState;
    [SerializeField] private LoseState loseState;

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
        if (loseState.canvasGroup.alpha == 1)
        {
            inputController.CanvasDisable();
        }
    }
    public override void OnExit()
    {
        base.OnExit();
    }
    public abstract void OnButtonClicked();
}
