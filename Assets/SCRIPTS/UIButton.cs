using System;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    private RectTransform RT;
    public string toScreen;
    public PressStyle style = PressStyle.down;

    void Start()
    {
        RT = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Release()
    {

        switch (style)
        {
            case PressStyle.down: RT.position += Vector3.up * 15; break;
            case PressStyle.scale: RT.localScale = Vector3.one; break;
        }
    }

    public void Press()
    {
        Sounds.Play("button");
        switch (style)
        {
            case PressStyle.down: RT.position -= Vector3.up * 15; break;
            case PressStyle.scale: RT.localScale = Vector3.one * 1.1f; break;
        }

        print("***********************************************-" + toScreen);
        if (!String.IsNullOrEmpty(toScreen))
            GamePlay.SwitchTo(toScreen);
    }



    public enum PressStyle
    {
        down, scale
    }
}