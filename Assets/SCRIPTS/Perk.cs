using UnityEngine;
using UnityEngine.UI;

public class Perk : MonoBehaviour
{
    private Image IM;

    public int focus;
    public int mood;
    public int progress;

    void Start()
    {
        IM = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Select()
    {
        GamePlay.CheckSelected(this);
        
    }
    public void Mark()
    {
        IM.color = Color.yellow;
        Sounds.Play( "dong" );
    }public void UNMark()
    {
        IM = GetComponent<Image>();
        IM.color = Color.white;
    }
}
