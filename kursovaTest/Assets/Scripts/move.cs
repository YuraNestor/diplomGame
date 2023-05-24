using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using org.mariuszgromada.math.mxparser;
using System.Globalization;
using System;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    public Function function;
    private float xx;
    private float yy=0;
    public float speed=1;
    public GameObject parent;
    public string strFunction;
    public float funcSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        strFunction = "y(x)=sin(x)";
        xx = 0;
        

        setFunc(strFunction);
        //function = new Function(t);
        
    }
    public void setFunc(Text t)
    {
        
        strFunction = t.text;
        function = new Function(strFunction);
        parent = transform.parent.gameObject;
        parent.transform.localPosition = new Vector3(0, yy-func(xx)+ parent.transform.localPosition.y, 0);
        Debug.Log(t.text);
        Debug.Log(yy);
        Debug.Log(func(xx));
    }
    public void setFunc(string t)
    {
        function = new Function(t);
        strFunction = t;
        parent = transform.parent.gameObject;
        parent.transform.localPosition = new Vector3(0, -func(xx), 0);
        //Debug.Log(t);
    }
    private float func(float xe)
    {
        Argument x = new Argument("x = " + xe.ToString(CultureInfo.InvariantCulture));
        Expression expression;
        expression = new Expression("y(x)", function, x);
        return Convert.ToSingle(expression.calculate());
    }
    
    // Update is called once per frame
    void Update()
    {
        Expression expression;
        Argument x = new Argument("x = " + xx.ToString(CultureInfo.InvariantCulture));
        yy = func(xx);
        transform.localPosition=new Vector3(xx, yy);
        expression = new Expression("der(" + strFunction.Replace("y(x)=", "") + " , x)", x);

        //label1.Text += " x= " + i.ToString() + "  sy=" + expression.calculate().ToString();
        funcSpeed = (float)expression.calculate();
        xx += speed * Time.deltaTime/(1+ Math.Abs(funcSpeed));
        Debug.Log(xx);

        
    }
}
