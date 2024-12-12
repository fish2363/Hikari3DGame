using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guid : MonoBehaviour
{
    [SerializeField] private GameObject Line;
    int count = 0;
    private void Start()
    {
        Line.SetActive(false);
    }
    public void Enabled()
    {
        if (count == 0)
        {
            ++count;
            Line.SetActive(true);
        }
       else
        {
            count = 0;
            Line.SetActive(false);
        }
  }

}
