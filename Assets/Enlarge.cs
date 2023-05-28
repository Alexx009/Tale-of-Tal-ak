using UnityEngine;
using UnityEngine.EventSystems;

public class Enlarge : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform rectTransform;
    private Vector3 originalScale;
    public float scaleFactor = 1.2f; // Amount to scale the UI element

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
{
    rectTransform.localScale = originalScale * scaleFactor;
}

public void OnPointerExit(PointerEventData eventData)
{
    rectTransform.localScale = originalScale;
}
}