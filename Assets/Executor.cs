using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class Executor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("Application.dataPath=" + Application.dataPath);
    }

    public void EXE()
    {
        Process p = new Process();
        p.StartInfo.FileName = Application.dataPath+"/Speech/ConsoleApp1.exe";
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.CreateNoWindow = true;
        p.Start();
        string line = p.StandardOutput.ReadLine();
        print("OUTPUT=" + line);
    }
    void Update()
    {
        
    }
}
