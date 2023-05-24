using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubuh : MonoBehaviour
{
    public GameObject bubuh;
    // Start is called before the first frame update
    public void Bubuhh(Transform transform)
    {
        //Debug.Log("i am buubuh"+transform.position+" "+bubuh);
        GameObject g=Instantiate(bubuh, transform.position, Quaternion.identity);

        Destroy(g, 1f);
    }

    
}
