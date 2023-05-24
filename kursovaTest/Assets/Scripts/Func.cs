using org.mariuszgromada.math.mxparser;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Func
{
    public Function function;
    public string defoltFunc = "y(x)=sin(x)";
    private string lf = "y(x)=1";
    private float oldX=0;
    private float oldY = 0;
    //public float speed = 1;
    //public GameObject parent;
    public string strFunction;
    public bool wasNaN=false;
    //public float funcSpeed;
    public Func(string funcStr)
    {
        
        setFunc(funcStr);
    }
    public Func()
    {
        
        setFunc(defoltFunc);
    }
    // Start is called before the first frame update
    //void Start()
    //{
    //    strFunction = "y(x)=sin(x)";
    //    oldX = 0;


    //    setFunc(strFunction);
    //    //function = new Function(t);

    //}
    //public void setFunc(Text t)
    //{

        
    //    setFunc(t.text);
    //}
    //public void setFunc(string strFunction)
    //{
    //    function = new Function(strFunction);
    //    parent = transform.parent.gameObject;
    //    parent.transform.localPosition = new Vector3(0, oldY - F(oldX) + parent.transform.localPosition.y, 0);
    //    Debug.Log(strFunction);
    //    Debug.Log(oldY);
    //    Debug.Log(F(oldX));
    //}
    public void setFunc(string strFunction)
    {
        if (function != null)
        {
            oldY = F(oldX);
        }
        this.strFunction= strFunction;
        function = new Function(strFunction);
        if (!validFunc(oldX))
        {
            Debug.Log("Dura VVela ne pravilno");
            function=new Function(lf);
            this.strFunction = lf;
        }
    }
    public Vector3 AxisDisplacement(Vector3 oldAxis)
    {
        return new Vector3(0, oldY - F(oldX) + oldAxis.y, 0);
    }
    
    public void ResetFuncMemory()
    {
        oldX = 0;
        oldY = 0;
    }
    public float FuncSpeed(float x)
    {
        Argument ax = new Argument("x = " + x.ToString(CultureInfo.InvariantCulture));
        Expression expression;
        expression = new Expression("der(" + strFunction.Replace("y(x)=", "") + " , x)", ax);
        var speed = expression.calculate();
        //Debug.Log(speed);
        if (Double.IsNaN(speed))
        {
            //Debug.Log("if");
            wasNaN = true;
            speed = 0.0;
        }
        else
        {
            wasNaN = false;
        }
        
        return Convert.ToSingle(speed);
    }

    public bool validFunc(float x)
    {
        //Debug.Log(F(x)+" - "+float.NaN);
        if (F(x) == 0 && wasNaN)
        {
            //Debug.Log("oooo");
            return false;
        }
        return true;
    }
    public float F(float x)
    {
        Argument ax = new Argument("x = " + x.ToString(CultureInfo.InvariantCulture));
        Expression expression;
        expression = new Expression("y(x)", function, ax);
        //oldY = F(x);
        oldX = x;
        var y = expression.calculate();
        if (Double.IsNaN(y))
        {
            wasNaN = true;
            y = 0.0;
        }
        else
        {
            wasNaN = false;
        }
        return Convert.ToSingle(y);
        
    }
    public override string ToString()
    {
        return strFunction;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    Expression expression;
    //    Argument x = new Argument("x = " + oldX.ToString(CultureInfo.InvariantCulture));
    //    oldY = F(oldX);
    //    transform.localPosition = new Vector3(oldX, oldY);
    //    expression = new Expression("der(" + strFunction.Replace("y(x)=", "") + " , x)", x);

    //    //label1.Text += " x= " + i.ToString() + "  sy=" + expression.calculate().ToString();
    //    funcSpeed = (float)expression.calculate();
    //    oldX += speed * Time.deltaTime / (1 + Math.Abs(funcSpeed));
    //    Debug.Log(oldX);


    //}
}
