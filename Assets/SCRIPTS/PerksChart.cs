using System;
using UnityEngine;

public class PerksChart : MonoBehaviour
{
    public FocusProgressBar PBfocus;
    public FocusProgressBar PBmood;
    public FocusProgressBar IQprogress;

    internal void SetData(float focus, float mood, float progress)
    {
        print("SETdATA FOR " +name+$"[{focus}:{mood}:{progress}]");
        PBfocus.SetData(focus);
        PBmood.SetData(mood);
        IQprogress.SetData(progress);
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
