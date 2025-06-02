using System;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    public static Perk SelectedPerk;
    public Image man;
    public Sprite man1, man2, man3;
    private static GamePlay IN;

    private void Awake()
    {
        IN = this;
    }

    void Start()
    {
        Screens.fader.Init();
        Screens.Show("StartScreen", 0.1f);
    }

    public static void SwitchTo(string screen)
    {
        if (screen == "Exit") 
        Application.Quit();
        else
        Screens.Show(screen,0.001f);
    }

    void Update()
    {

    }

    public static void CheckSelected(Perk perk)
    {
        if (SelectedPerk != null)
        {

            SelectedPerk.UNMark();
            if (SelectedPerk != perk)
            {
                SelectedPerk = perk;
                perk.Mark();
            }
            else
            {
                SelectedPerk = null;
                Sounds.Play("undo");

            }
        }
        else
        {

            SelectedPerk = perk;
            perk.Mark();
        }
    }

    internal static void UpdateMan(int focus, int mood, int progress)
    {
        int result = focus + mood + progress;
        
        if (result < 50)
            IN.man.sprite = IN.man1;
        else if(result<150)
            IN.man.sprite = IN.man2;
        else
            IN.man.sprite = IN.man3;

    }

}
