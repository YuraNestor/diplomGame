using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedBullet : SimpleBullet
{
    public void SetFunc(Func func)
    {
        if (enemyTarget != null)
        {
            return;
        }
        this.func = func;
        if (axis)
        {
            func.UpdateXY(transform.localPosition);
            axis.transform.localPosition = func.AxisDisplacement(axis.transform.localPosition);
            float x = transform.localPosition.x;
            transform.localPosition = new Vector2(x, func.F(x));            
        }
    }
    void Start()
    {
        if(func==null)
            func = new Func();
        axis = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        OneStepMove();
    }
}
