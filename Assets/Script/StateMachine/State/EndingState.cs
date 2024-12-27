using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class EndingState : State
{
    public Button button;
    public InputController inputController;
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
        GameManager.GamePause();
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