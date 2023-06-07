using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniConsole : MonoBehaviour
{
    private List<string> lines = new List<string>();
    private static string startString = "Air targets destroyed: ";

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
        
        
        string s=startString;
        s+=GetComponentInParent<ControlPanel>().GetPoints().ToString()+"\n";
        foreach(string line in lines)
        {
            s += line+"\n";
        }
        GetComponent<Text>().text = s;
    }
    private void OnDestroy()
    {
        Application.logMessageReceivedThreaded -= LogHandler;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
