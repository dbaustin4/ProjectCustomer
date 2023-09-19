using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonTextChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    public Color normalTextColor = Color.white;
    public Color highlightTextColor = Color.black;
    public Color selectedTextColor = Color.black;

    private Text buttonText;

    private void Start()
    {
        buttonText = GetComponentInChildren<Text>();
        SetTextColor(normalTextColor);
        Debug.Log("Normal");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetTextColor(highlightTextColor);
        Debug.Log("Highlighted");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetTextColor(normalTextColor);
    }

    public void OnSelect(BaseEventData eventData)
    {
        SetTextColor(selectedTextColor);
        Debug.Log("Clicked");
    }

    public void OnDeselect(BaseEventData eventData)
    {
        SetTextColor(normalTextColor);
    }

    private void SetTextColor(Color color)
    {
        if (buttonText != null)
        {
            buttonText.color = color;
        }
    }
}
