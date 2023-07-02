using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuidedGun : SimpleGun
{
    public GameObject shootOutBullet;
    // Start is called before the first frame update
    void Start()
    {
        fx = new Func();
        if (!string.IsNullOrEmpty(firstFuncStr))
        {
            fx.setFunc(firstFuncStr);
        }        
        axis = transform.GetChild(0).gameObject;
    }
    public override GameObject Shoot()
    {
        if(shootOutBullet == null)
        {
            shootOutBullet = base.Shoot();
            shootOutBullet.GetComponent<GuidedBullet>().SetFunc(fx);
            return shootOutBullet;
        }
        else
        {
            return null;
        }        
    }
    public void ShootBtn()
    {
         Shoot();       
    }
    public void SetFunc(string text)
    {
        fx.setFunc(text);        
        if (shootOutBullet != null)
        {
            shootOutBullet.GetComponent<GuidedBullet>().SetFunc(fx);
        }
    }
    public void SetFunc(Text text)
    {
        Debug.Log("Seted " + fx.ToString());
        SetFunc(text.text);
    }
}
