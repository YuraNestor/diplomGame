using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniConsole : MonoBehaviour
{
    private List<string> lines = new List<string>();
    
    // Start is called before the first frame update
    void Start()
    {
        Application.logMessageReceivedThreaded += LogHandler;
        
    }
    public void LogHandler(string logString, string stackTrace, LogType type)
    {
        
        lines.Add(logString);
        if (lines.Count > 6)
        {
            lines.RemoveAt(0);
        }
        
        
        string s=string.Empty;
        foreach(string line in lines)
        {
            s += line+"\n";
        }
        GetComponent<Text>().text = s;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
