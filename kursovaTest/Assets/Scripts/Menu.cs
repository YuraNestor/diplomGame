using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private string playerName;
    // Start is called before the first frame update
    void Start()
    {
        playerName = PlayerPrefs.GetString("name", string.Empty);
        
    }

    public void StartNewGame()
    {
        //SceneManager.LoadScene("Radar");
        StartCoroutine(CorotineStart());
        

    }
    public void SaveName(Text text)
    {
        playerName = text.text;
        PlayerPrefs.SetString("name", playerName);
    }
    IEnumerator CorotineStart()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Radar");
        asyncOperation.allowSceneActivation = false;
        while (string.IsNullOrEmpty(playerName))
        {
            transform.GetChild(1).gameObject.SetActive(true);
            yield return null;
        }
        asyncOperation.allowSceneActivation = true;

    }
    public void Exit()
    {
        Application.Quit();
    }
}
