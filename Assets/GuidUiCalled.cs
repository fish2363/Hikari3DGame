using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
public class GuidUiCalled : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField] RectTransform _guidF;
    public float end = -5f;
    public void OnPointerEnter(PointerEventData eventData)
    {

        _guidF.DOAnchorPos(new Vector2(689f, end), 0.5f, false).OnComplete(() => {  });
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _guidF.DOAnchorPos(new Vector2(689f, end + 500), 0.5f, false).OnComplete(() => { });
    }
}
