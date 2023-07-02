using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicalGameObject : MonoBehaviour
{
    public int maxHP=1;
    public int HP;
    public float destroyDeley;
    public int damage=1;
    public UnityEvent onDestroy;
    public UnityEvent onDamage;
    public UnityEvent addPoints;
    public PhysicalGameObject()
    {
        HP = maxHP;
    }
    // Start is called before the first frame update
    void Start()
    {
        HP = maxHP;
    }
    //protected void Outrun()
    //{
    //    Debug.Log(transform.position.x + " " + maxX);
    //    if(transform.position.x>=maxX|| transform.position.x <= -maxX || transform.position.y <= -maxY || transform.position.y >= maxY)
    //    {
    //        Debug.Log("Destroy " + gameObject.name);
    //        Destroy(gameObject);

    //    }
    //}
    //// Update is called once per frame
    //void Update()
    //{

    //}
    private void OnBecameInvisible()
    {
        Destroy(gameObject, destroyDeley);
    }

    public void DestroyMe()
    {
        onDestroy?.Invoke();
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        HP -= collision.gameObject.GetComponent<PhysicalGameObject>().damage;
        onDamage?.Invoke();
        if(HP <= 0)
        {
            if (collision.gameObject.tag=="FriendBullet" && gameObject.tag=="Enemy")
            {
                addPoints?.Invoke(); 
            }
            DestroyMe();
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        HP -= other.gameObject.GetComponent<PhysicalGameObject>().damage;
        onDamage?.Invoke();
        if (HP <= 0)
        {
            if (other.tag == "FriendBullet" && gameObject.tag == "Enemy")
            {
                addPoints?.Invoke();
            }
            DestroyMe();
        }
    }
}
