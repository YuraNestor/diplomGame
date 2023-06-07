using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PowerSystem : MonoBehaviour
{
    public GameObject blackOut;
    private int PPcount=0;
    public UnityEvent onBlackOut;
    // Start is called before the first frame update
    private void Start()
    {
        PPcount = transform.childCount;
    }
    
    public void Eclipse()
    {
        Color color = Color.black;
        //Debug.Log("transform.childCount " + transform.childCount + ", PPcount "+PPcount);
        
        color.a = 1 - ((float)transform.childCount-1f)/ (float)PPcount;
        Debug.Log("Power System damaged!");
        //Debug.Log("color.a " + color.a);
        blackOut.GetComponent<Image>().color = color;
        if (transform.childCount == 1)
        {
            onBlackOut?.Invoke();
        }
    }

}
