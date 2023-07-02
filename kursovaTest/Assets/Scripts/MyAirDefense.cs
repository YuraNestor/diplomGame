using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyAirDefense : PhysicalGameObject
{
    public bool is²elected;
    public void Select(bool select)
    {
        is²elected=select;
        if (select)
        {
            GetComponent<Image>().color = new Color(0, 0.8f, 0);
        }
        else
        {
            GetComponent<Image>().color = new Color(0, 0.6f, 0);
        }
    }
}
