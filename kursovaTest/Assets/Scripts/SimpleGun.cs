using org.mariuszgromada.math.mxparser;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGun : MonoBehaviour, IGun
{
    public string firstFuncStr;
    public int damage;
    public float startSpeed;
    public GameObject bullet;
    public Func fx;
    public GameObject axis;
    // Start is called before the first frame update

    public virtual GameObject Shoot()
    {
        var sBullet = bullet.GetComponent<SimpleBullet>();
        sBullet.speed = startSpeed;
        //sBullet.axis=axis;
        //sBullet.func = fx;
        fx.ResetFuncMemory();
        axis.transform.localPosition = fx.AxisDisplacement(Vector3.zero);
        sBullet.damage = damage;
        
        GameObject newBullet= Instantiate(bullet, transform.position, new Quaternion(0, 0, 0, 1));
        newBullet.transform.SetParent(axis.transform);
        newBullet.transform.rotation=transform.rotation;
        newBullet.GetComponent<SimpleBullet>().func = fx;
        newBullet.name = bullet.name;
        return newBullet;
    }
    public string GetFuncStr()
    {
        return fx.ToString();
    }
    void Start()
    {
        fx = new Func();
        if (!string.IsNullOrEmpty(firstFuncStr))
        {
            fx.setFunc(firstFuncStr);
        }
        axis = transform.GetChild(0).gameObject;
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
