using UnityEngine;
using UnityEngine.UI;

public class GuidFrame : MonoBehaviour
{
    [SerializeField] GuidUi _guidUi;
    Image _image;
    public Sprite sprite, currentsprite;
    void Start()
    {
        _image = GetComponent<Image>();
        _guidUi.OnClick += SpriteClick;
        _guidUi.OnClickUp += SpriteUp;
    }
    public void SpriteClick()
    {
        _image.sprite = sprite;
    }

    public void SpriteUp()
    {
        _image.sprite = currentsprite;
    }
}
