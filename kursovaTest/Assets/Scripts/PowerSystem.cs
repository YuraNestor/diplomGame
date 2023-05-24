using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerSystem : MonoBehaviour
{
    public GameObject blakOut;
    private int PPcount=0;
    // Start is called before the first frame update
    private void Start()
    {
        PPcount = transform.childCount;
    }
    
    public void Eclipse()
    {
        Color color = Color.black;
        Debug.Log("transform.childCount " + transform.childCount + ", PPcount "+PPcount);
        color.a = 1 - ((float)transform.childCount-1f)/ (float)PPcount;
        Debug.Log("color.a " + color.a);
        blakOut.GetComponent<Image>().color = color;
    }

}
