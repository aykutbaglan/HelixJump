using UnityEngine;
public abstract class State : MonoBehaviour
{
    [SerializeField] protected CanvasGroup canvasGroup;
    [SerializeField] protected BallController ballController;
    private const string BALL_TAG = "ball";
    //private void Awake()
    //{
    //    if (ballController == null) burada da unity üzerinde atama yý otomatik yapmasý saðlandý ama zaten referans ile verdim null ise yani boþ ise ata gibisinden.
    //    {
    //        ballController = GameObject.FindGameObjectWithTag(BALL_TAG).GetComponent<BallController>();
    //    }
    //}
    public virtual void OnEnter()
    {
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
    }
    public virtual void OnExit()
    {
        canvasGroup.alpha = 0.0f;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }
}
