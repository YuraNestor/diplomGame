using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarShip : MonoBehaviour
{
    public float KD = 1;
    private float t = 0;
    public int zalp = 4;
    private int z = 0;
    private Animation anim;
    private string[] animationNames = {"warShipCome", "warShipLeave"};
    private int krok=0;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (krok)
        {
            case 0:
                anim.Play(animationNames[0]);
                krok = 1;
                break;
            case 1:
                if (!anim.isPlaying)
                {
                    krok = 2;
                }
                break;
            case 2:
                if (z <= zalp)
                {
                    GetComponentInChildren<StupidGun>().Shoot();
                    t+=Time.deltaTime;
                    krok = 3;
                    z++;
                }
                else
                {
                    t = 0;
                    krok = 4;
                }
                break;
            case 3:
                t += Time.deltaTime;
                if (t > KD)
                {
                    t=0;
                    krok = 2;
                }
                break;
            case 4:
                 anim.Play(animationNames[1]);
                 krok = 5;             
                break;
            case 5:
                if (!anim.isPlaying)
                {
                    krok = 6;
                }

                break;
            case 6:
                t += Time.deltaTime;
                if (t > KD * 4)
                {
                    krok = 0;
                    t= 0;  
                    z= 0;
                }
                break;
            default:
                break;
        }  
    }

}
