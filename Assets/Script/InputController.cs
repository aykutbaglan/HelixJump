using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IDragHandler
{
    [SerializeField] private Transform main;
    [SerializeField] private float speed;
    [SerializeField] private CanvasGroup _canvasGroup;
    public void OnDrag(PointerEventData eventData)
    {
        var rotation = main.rotation;
        var current = rotation.eulerAngles.y;
        current += eventData.delta.x * -speed;
        rotation.eulerAngles = new Vector3(0, current, 0);
        main.rotation = rotation;
    }
    public void CanvasEnable()
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }
    public void CanvasDisable()
    {
        _canvasGroup.alpha = 0f;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }
}