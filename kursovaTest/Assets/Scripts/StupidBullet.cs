using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidBullet : PhysicalGameObject, IBullet
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
    public Transform enemyTarget;
    // Start is called before the first frame update
    void Start()
    {
        autoDitonationTime=Random.Range(minAutoDitonationTime,maxAutoDitonationTime);
        var cp = GameObject.Find("CONTROLPANEL").GetComponent<ControlPanel>();
        if(cp != null)
            addPoints.AddListener(() => { cp.AddOnePoint(); });
    }
    protected void RotateToDir()
    {
        Vector2 dir = transform.localPosition - preLocalPosition;
        float rotate = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(0, 0, rotate);
        //Debug.Log("rotate "+rotate);
        //Debug.Log("dir "+dir);
    }

    public void SetEnemyTarget(GameObject enemyTarget)
    {
        this.enemyTarget = enemyTarget.transform;
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
        if (enemyTarget != null)
        {
            transform.parent = null;
            transform.localPosition = Vector2.MoveTowards(transform.position, enemyTarget.position, speed * Time.deltaTime);
            
        }
        else
        {
            float x = transform.localPosition.x;
            x += speed * Time.deltaTime;
            transform.localPosition = new Vector3(x, F(x) * deflection);
        }
        

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
