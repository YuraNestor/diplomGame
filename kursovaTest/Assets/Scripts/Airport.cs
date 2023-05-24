using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airport : MonoBehaviour
{
    public float KD = 3;
    public float t = 0;
    public string[] funcStrings;
    private GameObject flyOutJet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flyOutJet == null)
        {
            if (t == 0)
            {
                if (funcStrings.Length != 0)
                {
                    
                    GetComponentInChildren<GuidedGun>()?.SetFunc(funcStrings[Random.Range(0, funcStrings.Length)]);
                }

                flyOutJet=GetComponentInChildren<IGun>().Shoot();

            }
            else if (t >= KD)
            {
                t = 0;
                return;
            }
            t += Time.deltaTime;
        }
        //if (GetComponentInChildren<GuidedGun>().shootOutBullet == null)
        //{
        //    if (t == 0)
        //    {
        //        if (funcStrings.Length != 0)
        //        {
        //            GetComponentInChildren<GuidedGun>().SetFunc(funcStrings[Random.Range(0, funcStrings.Length)]);
        //        }

        //        GetComponentInChildren<GuidedGun>().Shoot();

        //    }
        //    else if (t >= KD)
        //    {
        //        t = 0;
        //        return;
        //    }
        //    t += Time.deltaTime;
        //}
        
    }
}
