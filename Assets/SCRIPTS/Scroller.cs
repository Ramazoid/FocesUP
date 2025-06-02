using UnityEngine;

public class Scroller : MonoBehaviour
{
    public RectTransform scrollPanel;
    private float startY;
    private Vector2 startposition;
    private float nowY;

    void Start()
    {
        
    }

    public void Init()
    {

        foreach (RectTransform r in scrollPanel)
        {
            r.GetComponent<Perk>().UNMark();
            GamePlay.SelectedPerk = null;
        }
    }
    private void OnBecameVisible()
    {
        print("**Scrollerhere");
    }

    /*
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startY = Input.mousePosition.y;
            startposition = scrollPanel.anchoredPosition;
        }
        if (Input.GetMouseButton(0))
        {
            nowY=Input.mousePosition.y;
            print(scrollPanel.anchoredPosition);
            if(scrollPanel.anchoredPosition.y+ nowY - startY < -193 && scrollPanel.anchoredPosition.y + nowY - startY > -210)
            scrollPanel.anchoredPosition = startposition + new Vector2(0, nowY - startY);
        }
    }*/
}
