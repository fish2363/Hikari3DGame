using System;
using UnityEngine;

[Serializable]
public class NotifyValue<T>
{
    public delegate void ValueChanged(T prev, T next);
    public event ValueChanged OnValueChanged; // �� ���� �̺�Ʈ

    [SerializeField] private T value; // ������ �� ����

    public T Value // �� ������Ƽ
    {
        get => value;
        set
        {
            T before = this.value;
            this.value = value;
            if ((before == null && value != null) || !before.Equals(this.value)) // Null Ȯ�� & �� ���� üũ
            {
                OnValueChanged?.Invoke(before, this.value); // �� ���� �̺�Ʈ ����
            }
        }
    }

    public NotifyValue()
    {
        value = default(T);
    }

    public NotifyValue(T value)
    {
        this.value = value;
    }
}

