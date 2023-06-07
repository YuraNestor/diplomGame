using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jet : MonoBehaviour
{
    public float KD = 6;
    public float timer;
    public int zalp=1;
    
    // Start is called before the first frame update
    void Start()
    {
        Airport airport = GetComponentInParent<Airport>();
        timer = Random.Range(0.01f, KD/2);
        GetComponent<PhysicalGameObject>().onDestroy.AddListener(() => { airport.KDMultiplier(2); });
        var cp = GameObject.Find("CONTROLPANEL").GetComponent<ControlPanel>();
        if (cp != null)
            GetComponent<PhysicalGameObject>().addPoints.AddListener(() => { cp.AddOnePoint(); });
    }

    // Update is called once per frame
    void Update()
    {
        if(timer == -1)
        {
            //Debug.Log("Distance " + Vector2.Distance(GetComponent<SimpleBullet>().enemyTarget.position, transform.position));
            if (Vector2.Distance(GetComponent<SimpleBullet>().enemyTarget.position, transform.position) < 0.5f)
            {
                Destroy(gameObject);
            }
            return;
        }
        if (timer == 0)
        {
            GetComponentInChildren<IGun>().Shoot();
            
            
            zalp--;
            
        }
        else if(timer > KD)
        {
            timer = 0;
            if (zalp == 0)
            {
                timer = -1;
                GetComponent<SimpleBullet>().enemyTarget = transform.parent;
            }
            return;
        }
        timer+=Time.deltaTime;
        
    }
}
