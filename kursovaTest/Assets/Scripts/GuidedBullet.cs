using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedBullet : SimpleBullet
{
    //public GameObject axis;
    // Start is called before the first frame update

    public void SetFunc(Func func)
    {
        this.func = func;
        if (axis)
        {
            //Target();
            float x = transform.localPosition.x;
            transform.localPosition = new Vector2(x, func.F(x));
            axis.transform.localPosition = func.AxisDisplacement(axis.transform.localPosition);
            
            //Target();
            
        }
        
    }
    void Start()
    {
        if(func==null)
            func = new Func();
        //nextX=0;
        axis = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
        OneStepMove();
    }
}
