using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : PhysicalGameObject
{
    public Func func;
    public float speed=1;
    public GameObject axis;
    private Vector3 preLocalPosition;
    public Vector2 target;
    public int targetFindingStep=10;
    private int step = 0;
    private float t=0.02f;
    public Transform enemyTarget;
    //public float nextX;
    
    // Start is called before the first frame update
    void Start()
    {
        if (func == null)
            func = new Func();
        //nextX=0;
        
        axis = transform.parent.gameObject;
    }
    protected void RotateToDir()
    {
        Vector2 dir = transform.localPosition - preLocalPosition;
        
        float rotate = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //float curentRotation = transform.localRotation.eulerAngles.z;
        Quaternion q = Quaternion.Euler(0, 0, rotate);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, q, Mathf.Abs(speed * Time.deltaTime));
        //transform.localRotation = Quaternion.Euler(0, 0, rotate);

        //Debug.Log("rotate "+rotate);
        //Debug.Log("dir "+dir);
    }
    public void Target()
    {
        if(enemyTarget != null)
        {
            target = enemyTarget.position;
            var zAngle = transform.localRotation.eulerAngles.z;
            transform.SetParent(null);
            transform.localRotation = Quaternion.Euler(0, 0, zAngle);
            return;
        }
        float x = transform.localPosition.x;
        //transform.localPosition = new Vector2(x, func.F(x));
        //Debug.Log("x+ ="+speed * Time.deltaTime * targetFindingStep /*/ (1 + Math.Abs(func.FuncSpeed(x)))*/);
        x += speed * t /*/ (1 + Math.Abs(func.FuncSpeed(x)))*/;
        
        //x += speed * Time.deltaTime * targetFindingStep;
        target = new Vector2(x, func.F(x));
    }
    
    public virtual void OneStepMove()
    {
        //float x = transform.localPosition.x;
        //x += speed * Time.deltaTime / (1 + Math.Abs(func.FuncSpeed(x)));

        //transform.localPosition = new Vector3(x, func.F(x));
        if (step == 0)
        {
            Target();
            t = 0;
        }
        else if (step == targetFindingStep-1)
        {
            step = -1;
        }
        t+=Time.deltaTime;
        step++;
        float distance = Vector2.Distance(transform.localPosition, target);
        if (distance / targetFindingStep > speed * Time.deltaTime)
            distance = Mathf.Abs(speed * Time.deltaTime * targetFindingStep);
        transform.localPosition = Vector2.MoveTowards(transform.localPosition, target, distance/targetFindingStep);

        RotateToDir();
        preLocalPosition = transform.localPosition;
        //Outrun();
    }
    // Update is called once per frame
    void Update()
    {
        OneStepMove();
        
        //float x = transform.localPosition.x;
        //x+= speed * Time.deltaTime /( 1 + Math.Abs(func.FuncSpeed(x)));
        //transform.localPosition=new Vector3(x, func.F(x));
        
        //nextX+= speed * Time.deltaTime / (1 + Math.Abs(func.FuncSpeed(nextX)));
    }
}
