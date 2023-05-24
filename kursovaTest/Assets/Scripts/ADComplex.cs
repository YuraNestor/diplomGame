using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ADComplex : MonoBehaviour
{

    private GameObject selectedAD;
    [SerializeField]
    private Text info;
    [SerializeField]
    private InputField inputField;

    public void SelectAD(GameObject ad)
    {
        UnselectAllAD();
        ad.GetComponent<MyAirDefense>().Select(true);
        selectedAD = ad;
        info.text = selectedAD.name;
        inputField.text = selectedAD.GetComponentInChildren<GuidedGun>().GetFuncStr();
    }
    public void UnselectAllAD()
    {
        selectedAD = null;
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<MyAirDefense>().Select(false);
        }
    }
    public void SetADFunc(Text text)
    {
        if (selectedAD != null)
        {
            selectedAD.GetComponentInChildren<GuidedGun>().SetFunc(text);
        }
        else
        {
            info.text = "null";
            inputField.text = "connection lost";
        }
    }
    public void Shoot()
    {
        if(selectedAD != null)
        {
            var shootOutBullet =selectedAD.GetComponentInChildren<SimpleGun>().Shoot();
            Debug.Log("launched " + shootOutBullet.GetComponent<GuidedBullet>().func.ToString());
        }
        else
        {
            info.text = "null";
            inputField.text = "connection lost";
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
