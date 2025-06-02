using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(CanvasGroup))]
public class Fader : MonoBehaviour
{
    private RectTransform RT;
    public Image IM;
   

    public CanvasGroup CG { get; private set; }

    void Start()
    {
        
        
       
       
        //IM = GetComponent<Image>();
    }

    public void FadeOUT(float delta)
    {
        StartCoroutine(Out(delta));
    }

    IEnumerator Out(float delta)
    {
        while(CG.alpha>=0)
            {
            CG.alpha -= delta;
            yield return new WaitForSeconds(0.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void Init()
    {
        RT = GetComponent<RectTransform>();
        RT.SetAsLastSibling();
        CG = GetComponent<CanvasGroup>();CG.alpha = 1;
        RT.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, Screen.width);
        RT.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, Screen.height);

        FadeOUT(0.0001f);
    }
}
