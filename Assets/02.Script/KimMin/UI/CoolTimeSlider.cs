using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolTimeSlider : MonoBehaviour
{
    [SerializeField] private Color _filledCol;

    private List<Image> _imageList;

    private float _childCount;
    private float _currentTime;
    private float _targetTime;

    public bool isCoolTime;

    private void Awake()
    {
        _childCount = transform.childCount;
        _imageList = new List<Image>();

        for (int i = 0; i < _childCount; i++)
            _imageList.Add(transform.Find($"Fill{i + 1}").GetComponent<Image>());

        foreach(Image image in _imageList)
        {
            image.color = Color.white;
        }
    }

    private void Update()
    {
        if (isCoolTime)
        {
            SetSlider();
        }
    }

    public void CallbackSlider(float value)
    {
        isCoolTime = true;
        _currentTime = value;
        _targetTime = value;
    }

    public void SetSlider()
    {
        _currentTime -= Time.deltaTime;
       
        for (int i = 0; i < _childCount; i++)
        {
            _imageList[i].color = (_currentTime / _targetTime) * _childCount > i ? _filledCol : Color.white;
        }
    }
}
