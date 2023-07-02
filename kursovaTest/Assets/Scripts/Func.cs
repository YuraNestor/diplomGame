using org.mariuszgromada.math.mxparser;
using System;
using System.Globalization;
using UnityEngine;

public class Func
{
    public Function function;
    public string defoltFunc = "y(x)=sin(x)";
    private string lf = "y(x)=1";
    private float oldX=0;
    private float oldY = 0;
    public string strFunction;
    public bool wasNaN=false;
    public Func(string funcStr)
    {
        setFunc(funcStr);
    }
    public Func()
    {
        setFunc(defoltFunc);
    }
    public void setFunc(string strFunction)
    {
        //if (function != null)
        //{
        //    oldY = F(oldX);
        //}
        this.strFunction= strFunction;
        function = new Function(strFunction);
        if (!validFunc(oldX))
        {
            Debug.Log("Failed function");
            function=new Function(lf);
            this.strFunction = lf;
        }
    }
    public void UpdateXY(Vector2 xy)
    {
        oldX= xy.x;
        oldY = xy.y;
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
        if (Double.IsNaN(speed))
        {
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
        if (F(x) == 0 && wasNaN)
        {
            return false;
        }
        return true;
    }
    public float F(float x)
    {
        Argument ax = new Argument("x = " + x.ToString(CultureInfo.InvariantCulture));
        Expression expression;
        expression = new Expression("y(x)", function, ax);
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
}
