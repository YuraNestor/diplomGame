using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ADComplex : MonoBehaviour
{

    private GameObject selectedAD;
    [SerializeField]
    private Text info;
    [SerializeField]
    private InputField inputField;
    [SerializeField]
    private UnityEvent onGameOver;
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
            if (shootOutBullet != null)
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
    public void gameOver()
    {
        onGameOver?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)
        {
            gameOver();
            gameObject.SetActive(false);
        }
    }
}
