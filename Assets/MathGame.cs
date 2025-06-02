using System;
using UnityEngine;
using UnityEngine.UI;

public class MathGame : MonoBehaviour
{
    public FocusProgressBar timeBar;
    public Text questText;
    public Text a1;
    public Text a2;
    public Text a3;
    public Text a4;
    private float time;
    private bool gameStarted=false;
    private int answer;
    public int[] answers = new int[4];

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {
            float seconds = Time.time - time;
            if (seconds >= 120)
            {
                gameStarted = false;
                Sounds.Play("loose");
                Perks.Loose();
                Init();
                GamePlay.SwitchTo("MainScreen");
            }
            timeBar.SetTimeString(seconds);
        }
    }
    public void Init()
    {

         time = Time.time;
        gameStarted = true;
        SetQuestion();
    }

    private void SetQuestion()
    {
        int n1 = UnityEngine.Random.Range(1, 20);
        int n2 = UnityEngine.Random.Range(1, 20);
        answer = n1 + n2;
        questText.text = n1 + "+" + n2 + "=?";
        bool haveRight = false;
        while (!haveRight)
        {
            int an1 = UnityEngine.Random.Range(1, 20);
            if (UnityEngine.Random.Range(0, 4) == 0)
                an1 = answer;

            int an2 = UnityEngine.Random.Range(1, 20);
            if (UnityEngine.Random.Range(0, 4) == 0)
                an2 = answer;

            int an3 = UnityEngine.Random.Range(1, 20);
            if (UnityEngine.Random.Range(0, 4) == 0)
                an3 = answer;

            int an4 = UnityEngine.Random.Range(1, 20);
            if (UnityEngine.Random.Range(0, 4) == 0)
                an4 = answer;

            a1.text = an1.ToString();
            a2.text = an2.ToString();
            a3.text = an3.ToString();
            a4.text = an4.ToString();
            answers[0] = an1;
            answers[1] = an2;
            answers[2] = an3;
            answers[3] = an4;

            if (an1 == answer || an2 == answer || an3 == answer || an4 == answer)
                haveRight = true;
            if (an1 == an2 || an1 == an3 || an1 == an4)
                haveRight = false;
            if (an2 == an3 || an1 == an4)
                haveRight = false;
            if (an3 == an4 || an2 ==an4 || an3== an4)
                    haveRight = false;
        }

    }

    public void Check(int n)
    {
        if (answers[n] == answer)
        {
            Sounds.Play("win");
            Perks.Win();
            SetQuestion();
        }
        else
        {
            Sounds.Play("loose");
            Perks.Loose();
            SetQuestion();
        }
    }
}
