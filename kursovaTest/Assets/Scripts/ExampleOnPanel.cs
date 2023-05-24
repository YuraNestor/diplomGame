using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExampleOnPanel : MonoBehaviour
{

    // Start is called before the first frame update
    public void BtnClick(InputField inputField)
    {
        inputField.text = GetComponentInChildren<Text>().text;      
    }
    public void Edit(Text text)
    {
        GetComponentInChildren<Text>().text = text.text;
    }
    
}
