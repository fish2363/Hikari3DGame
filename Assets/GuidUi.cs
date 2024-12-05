using System;
using UnityEngine;
using UnityEngine.EventSystems;
public class GuidUi : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{
    public Action OnClick, OnClickUp;
    [SerializeField] private LineCollider line;
    private bool Cheack = false;
    private void Start()
    {
        line.gameObject.SetActive(false);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (Cheack)
            line.gameObject.SetActive(false);
       else if (!Cheack)
            line.gameObject.SetActive(true);
        OnClick?.Invoke();
        Debug.Log("≈¨∏Øµ ");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnClickUp?.Invoke();
        Debug.Log("≈¨∏Ø«ÿ¡¶µ ");
        if (Cheack)
            Cheack = false;
        else if (!Cheack)
        Cheack = true;
    }
}
