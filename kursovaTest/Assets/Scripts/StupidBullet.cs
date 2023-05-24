using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidBullet : PhysicalGameObject
{
    public int funcNumber = 0;
    public float speed = 1;
    public GameObject axis;
    public Vector3 preLocalPosition;
    public float deflection=1;
    public float minAutoDitonationTime = 2;
    public float maxAutoDitonationTime = 10;
    private float autoDitonationTime;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        autoDitonationTime=Random.Range(minAutoDitonationTime,maxAutoDitonationTime);
    }
    protected void RotateToDir()
    {
        Vector2 dir = transform.localPosition - preLocalPosition;
        float rotate = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(0, 0, rotate);
        //Debug.Log("rotate "+rotate);
        //Debug.Log("dir "+dir);
    }
    public float F(float x)
    {
        switch (funcNumber)
        {
            case 0:
                return 0;
                
            case 1:
                return Mathf.Sin(x);
                

            default: return x;
        }

    }
    public virtual void OneStepMove()
    {
        float x = transform.localPosition.x;
        x += speed * Time.deltaTime;
        transform.localPosition = new Vector3(x, F(x)*deflection);

        RotateToDir();
        preLocalPosition = transform.localPosition;
        //Outrun();
    }
    private void OnDestroy()
    {
        Destroy(axis);
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > autoDitonationTime)
        {
            DestroyMe();
        }
        OneStepMove();
    }
}
