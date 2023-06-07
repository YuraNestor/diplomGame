using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationMissile : MonoBehaviour
{
    // Start is called before the first frame update
    public string targetTag;
    public string targetLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == targetTag)
        {
            
            GetComponentInParent<IBullet>().SetEnemyTarget(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
