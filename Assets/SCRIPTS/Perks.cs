using System;
using UnityEngine;

public class Perks : MonoBehaviour
{
    public RectTransform perksContainer;
    public PerksChart chart;
    public PerksChart chart2;
    public PerksChart chart3;
    public PerksChart chart4;
    public PerksChart chart5;
    public int focus;
    public int mood;
    public int progress;
    public static Perks IN;

    private void Awake()
    {
        IN = this;
    }

    void Start()
    {
        string data;

        if (PlayerPrefs.HasKey("Focus.data"))
        {
            data = PlayerPrefs.GetString("Focus.data");
            if (!String.IsNullOrEmpty(data))
            {
                string[] idata = data.Split(":");

                focus = int.Parse(idata[0]);
                mood = int.Parse(idata[1]);
                progress = int.Parse(idata[2]);
            }
            else
            {
                focus = mood = progress = 0;

            }
        }
        else
        {
            focus = mood = progress = 0;

        }


        SavePrefs();
        UpdateChart();
        GamePlay.UpdateMan(focus, mood,progress);
    }

    public void SavePrefs()
    {
        string data = focus + ":" + mood + ":" + progress;
        PlayerPrefs.SetString("Focus.data", data);
    }

    private void UpdateChart()
    {
        chart.SetData(focus, mood, progress);
        chart2.SetData(focus, mood, progress);
        chart3.SetData(focus, mood, progress);
        chart4.SetData(focus, mood, progress);
        chart5.SetData(focus, mood, progress);
    }

    void Update()
    {

    }
    public void UpdatePerks()
    {
        Perk p = GamePlay.SelectedPerk;

        if (p != null)
        {
            focus += p.focus; focus = focus > 100 ? 100 : focus;
            mood += p.mood; mood = mood > 100 ? 100 : mood;
            progress += p.progress; progress = progress > 100 ? 100 : progress;
        }

        UpdateChart();
        GamePlay.UpdateMan(focus, mood, progress);
        SavePrefs();
        GamePlay.SwitchTo("MainScreen");
    }

    public static void Win(int d=5)
    {
        IN.progress += d;
        IN.focus += 1;
        IN.progress = IN.progress > 100 ? 100 : IN.progress;
        IN.focus = IN.focus > 100 ? 100 : IN.focus;
        IN.UpdateChart();
        GamePlay.UpdateMan(IN.focus, IN.mood, IN.progress);
        IN.SavePrefs();
    }

    public static void Loose(int d=5)
    {
        IN.progress -= d;
        IN.focus -= 1;
        
        IN.progress = IN.progress <0? 0 : IN.progress;
        IN.focus= IN.focus<0? 0 : IN.focus;
        IN.UpdateChart();
        GamePlay.UpdateMan(IN.focus, IN.mood, IN.progress);
        IN.SavePrefs();
    }
}
