using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPlant : PhysicalGameObject
{
    // Start is called before the first frame update
    void Start()
    {
        onDamage.AddListener(() => { DestoyChild(0); });
        onDestroy.AddListener(() => { GetComponentInParent<PowerSystem>().Eclipse(); });
    }
    public void DestoyChild(int number)
    {
        if(transform.childCount>number)
            Destroy(transform.GetChild(number).gameObject);
    }

    // Update is called once per frame
    
}
