using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Screens : MonoBehaviour
{
    public List<RectTransform> panels;
    public static Fader fader;
    private static Screens IN;

    private void Awake()
    {
        IN = this;
    }

    void Start()
    {

        List<RectTransform> rects = FindObjectsByType<RectTransform>(FindObjectsSortMode.InstanceID).ToList<RectTransform>();
        rects.ForEach((r) =>
        {
            if (r.name.Contains("Screen"))
            {
                r.anchoredPosition = Vector3.right * 2000;
                float scalex = Screen.width/r.rect.width  ;
                float scaley = Screen.height/r.rect.height ;
                
                Vector2 scale = new Vector2(scalex, scaley);
                r.localScale = scale;   
                
                panels.Add(r);
            }
            if (r.name.Contains("Fader"))
            
                fader = r.GetComponent<Fader>();
           
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal static void Show(string panelname,float delta)
    {
        fader.Init();
        RectTransform r = IN.panels.Find(((p) => p.name == panelname));
        if(r==null)
            throw new Exception($"there is no panel named[{panelname}]");
        r.gameObject.SetActive (true);
        r.anchoredPosition= Vector3.zero;
        r.SetAsLastSibling();
        r.SendMessage("Init",SendMessageOptions.DontRequireReceiver);
        fader.Init();
        fader.FadeOUT(delta);
    }
}
