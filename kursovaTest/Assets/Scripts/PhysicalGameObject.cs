using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicalGameObject : MonoBehaviour
{
    public int maxHP=1;
    public int HP;
    public float destroyDeley;
    //public static float maxY=0;
    //public static float maxX=0;
    public int damage=1;
    //public GameObject bubuh;
    public UnityEvent onDestroy;

    public UnityEvent onDamage;
    public PhysicalGameObject()
    {
        HP = maxHP;
    }
    // Start is called before the first frame update
    void Start()
    {
        //if (maxY == 0)
        //{
        //    Debug.Log("RectTransform");
        //    //var rt= 
        //    RectTransform rectTransform = GameObject.Find("Canvas").GetComponent<RectTransform>();
        //    maxX = rectTransform.sizeDelta.x * rectTransform.pivot.x * rectTransform.localScale.x - 1;
        //    maxY = rectTransform.sizeDelta.y * rectTransform.pivot.y * rectTransform.localScale.y - 1;
        //}
        
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

            //if (bubuh != null)
            //{
            //    GameObject bubuhh = Instantiate(bubuh, transform.position, Quaternion.identity);
            //    Destroy(bubuhh, 0.3f);
            //}
            DestroyMe();


        }
    }
    private void OnParticleCollision(GameObject other)
    {
        
        //Debug.Log(gameObject.name+" "+ other.name);
        HP -= other.gameObject.GetComponent<PhysicalGameObject>().damage;
        onDamage?.Invoke();
        if (HP <= 0)
        {

            //if (bubuh != null)
            //{
            //    GameObject bubuhh = Instantiate(bubuh, transform.position, Quaternion.identity);
            //    Destroy(bubuhh, 0.3f);
            //}
            DestroyMe();

        }
    }
}
