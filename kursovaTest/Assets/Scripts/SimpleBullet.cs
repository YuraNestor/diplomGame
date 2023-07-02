using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : PhysicalGameObject, IBullet
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
    public void SetEnemyTarget(GameObject enemyTarget)
    {
        this.enemyTarget = enemyTarget.transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (func == null)
            func = new Func();       
        axis = transform.parent.gameObject;
    }
    protected void RotateToDir()
    {      
        Vector2 dir = target - (Vector2)transform.localPosition /*- preLocalPosition*/;        
        float rotate = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.Euler(0, 0, rotate);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, q, Mathf.Abs(speed * Time.deltaTime));       
    }
    public void Target()
    {
        if(enemyTarget != null)
        {
            target = enemyTarget.position;
            if(transform.parent != null)
            {
                speed /= 2;
                var zAngle = transform.localRotation.eulerAngles.z;
                transform.SetParent(null);
                transform.localRotation = Quaternion.Euler(0, 0, zAngle);
            }            
            return;
        }
        else if(transform.parent == null)
        {
            DestroyMe();            
        }
        float x = transform.localPosition.x;
        x += speed * t;
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
        transform.localPosition = Vector2.MoveTowards(transform.localPosition, target, speed * Time.deltaTime);
        RotateToDir();
        preLocalPosition = transform.localPosition;        
    }
    // Update is called once per frame
    void Update()
    {
        OneStepMove();
    }
}
