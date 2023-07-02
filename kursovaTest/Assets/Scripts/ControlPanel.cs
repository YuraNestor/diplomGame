using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlPanel : MonoBehaviour
{
    private Animation anim;
    [SerializeField]
    private string[] animationNames = { "PanelDownAnimation", "PanelUpAnimation" };
    [SerializeField]
    private GameObject pauseBlur;
    private int points=0;
    private int hightPoints = 0;
    [SerializeField]
    private int toWinPoints=15;
    public GameObject povistka;
    public InterstitialAd ad;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        hightPoints = PlayerPrefs.GetInt("hs", 0);
        if (hightPoints >= toWinPoints)
            toWinPoints += hightPoints;
    }    
    public void Pause()
    {
        ad.LoadAd();
        if(!anim.isPlaying)
            StartCoroutine(CorotinePause());
    }    
    public void Again()
    {
        SceneManager.LoadScene("Radar");
        AudioListener.pause = false;
        var dies = PlayerPrefs.GetInt("d", 0);
        dies++;
        PlayerPrefs.SetInt("d", dies);
        if (dies == 3)
        {
            ad.ShowAd();
            PlayerPrefs.SetInt("d", 0);
        }
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MENU");
        AudioListener.pause = false;
        var dies = PlayerPrefs.GetInt("d", 0);
        dies++;
        PlayerPrefs.SetInt("d", dies);
        if (dies == 3)
        {
            ad.ShowAd();
            PlayerPrefs.SetInt("d", 0);
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void AddOnePoint()
    {
        points++;
        if (points > hightPoints)
        {
            hightPoints = points;
            PlayerPrefs.SetInt("hs", hightPoints);
        }
        if(points >= toWinPoints)
        {
            StartCoroutine(CorotineWin());
        }
    }
    public int GetPoints() 
    {
        return points;
    }
    // Update is called once per frame
    IEnumerator CorotinePause()
    {
        bool wasPause = Time.timeScale is 0 ? true:false;
        Time.timeScale = 1;
        anim.Play(animationNames[0]);
        while (anim.isPlaying)
        {
            yield return null;
        }
        transform.GetChild(0).gameObject.SetActive(wasPause);
        transform.GetChild(1).gameObject.SetActive(!wasPause);
        pauseBlur.SetActive(!wasPause);
        anim.Play(animationNames[1]);
        while (anim.isPlaying)
        {
            yield return null;
        }
        AudioListener.pause = !wasPause;
        Time.timeScale = wasPause ? 1:0;
    }
    IEnumerator CorotineWin()
    {
        povistka.SetActive(true);
        povistka.transform.GetChild(2).GetComponent<Text>().text=PlayerPrefs.GetString("name");
        AudioListener.pause = true;
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(2f);
        povistka.transform.GetChild(0).gameObject.SetActive(true);
    }
}
