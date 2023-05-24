using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidGun : MonoBehaviour, IGun
{
    public int damage;
    public float startSpeed;
    public GameObject bullet;
    
    //public GameObject axis;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public virtual GameObject Shoot()
    {
        var sBullet = bullet.GetComponent<StupidBullet>();
        sBullet.speed = startSpeed;
        //sBullet.axis=axis;
        //sBullet.func = fx;
        GameObject axis=Instantiate(new GameObject(), transform.position, transform.rotation);
        axis.name = "Axis";
        sBullet.damage = damage;
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.transform.SetParent(axis.transform);
        newBullet.GetComponent<StupidBullet>().funcNumber = Random.Range(0, 4);
        newBullet.GetComponent<StupidBullet>().deflection = Random.Range(-1f, 1.5f);
        newBullet.GetComponent<StupidBullet>().axis = axis;
        newBullet.name = bullet.name;
        return newBullet;
    }
    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
