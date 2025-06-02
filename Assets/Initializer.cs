using UnityEngine;

public class Initializer : MonoBehaviour
{
    public PerksChart chart;
    void Start()
    {

    }

    public void Init()
    {

        chart.SetData(Perks.IN.focus, Perks.IN.mood, Perks.IN.progress);
    }
}
