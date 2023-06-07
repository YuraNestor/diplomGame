using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour
{
    public Text text;
    public float attenuationSpeed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        var c = text.color;
        c.a -= Time.deltaTime * attenuationSpeed;
        text.color = c;
        if (c.a <= 0.01f)
        {
            AudioListener.pause = true;
            transform.GetChild(0).gameObject.SetActive(true);
            gameObject.GetComponent<GameOverText>().enabled = false;
        }
    }
}
