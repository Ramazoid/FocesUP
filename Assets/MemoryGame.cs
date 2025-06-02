using System;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class MemoryGame : MonoBehaviour
{
    public FocusProgressBar timeBar;
    public List<Cell> gamecells;
    public Sprite hidden;
    private Cell firstCell;
    private float time;
    private bool gameStarted;
    public List<Sprite> cells;

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
                Perks.Loose(5);
                Init();
                GamePlay.SwitchTo("MainScreen");
            }
            timeBar.SetTimeString(seconds);
        }
    }
    public void Init()
    {
        firstCell = null;
        time = Time.time;
        gameStarted = true;
        SetCells();
    }

    private void SetCells()
    {
        int[] counts = new int[cells.Count];

        bool allevent = false;

        while (!allevent)
        {
            for (int i = 0; i < counts.Length; i++) counts[i] = 0;
            foreach (Cell c in gamecells)
            {
                c.hidden = hidden;
                int n = Random.Range(0, cells.Count);
                counts[n]++;
                c.n = n;
                c.hidden = hidden;
                c.Hide();
                c.opened = false;
                c.open = cells[n];
                c.Check = CheckCells;

                c.transform.localScale = Vector3.one;
            }
            allevent = true;
            for (int i = 0; i < counts.Length; i++) if (counts[i] % 2 != 0) allevent = false;

        }

        for (int i = 0; i < counts.Length; i++) print($"[i]-> {counts[i]}");

    }
    public void CheckCells(Cell c)
    {
        if (firstCell == null)
            firstCell = c;
        else
        {
            if (firstCell.n == c.n)
            {
                Perks.Win(5);
                Sounds.Play("win");
                CheckLevel();
            }
            else
            {
                print("********************************LOOSE");
                Perks.Loose(1);
                Sounds.Play("loose");
                CheckLevel();
                //Thread.Sleep(2000);
                firstCell.FlipToHide();
                c.FlipToHide();
            }
            firstCell = null;
        }

    }

    private void CheckLevel()
    {
        int opened = 0;
        foreach (Cell c in gamecells) if (c.opened) opened++;
        if(opened==gamecells.Count) GamePlay.SwitchTo("MemoryGameScreen");
    }
}
