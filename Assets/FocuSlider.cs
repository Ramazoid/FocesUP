using UnityEngine;
using UnityEngine.XR;

public class FocuSlider : MonoBehaviour
{
    public RectTransform indicator;
    public RectTransform hand;
    private bool drag;
    private Vector3 startDeagHandPos;
    private float startdragX;
    private float value;
    public AudioSource player;

    void Start()
    {
        print("slider :" + name);
        if(PlayerPrefs.HasKey(name))
        {
            float x = PlayerPrefs.GetFloat(name);
            hand.anchoredPosition = new Vector3(x, 0, 0);
            indicator.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 12, hand.anchoredPosition.x);
        }else
            hand.anchoredPosition = new Vector3(295, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (drag)
        {
            float nowposX = Input.mousePosition.x;

            hand.localPosition = startDeagHandPos + new Vector3(-startdragX + nowposX, 0, 0);
            if (hand.anchoredPosition.x <= 0)
                hand.anchoredPosition = new Vector3(0, 0, 0);
            if (hand.anchoredPosition.x >= 290)
                hand.anchoredPosition = new Vector3(295, 0, 0);

            print(hand.anchoredPosition.x);
            indicator.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 12, hand.anchoredPosition.x);
        }

        value = (hand.anchoredPosition.x) / 290;
        player.volume = value;
        PlayerPrefs.SetFloat(name, hand.anchoredPosition.x);
    }
    public void StartDragHand()
    {
        drag = true;
        startDeagHandPos = hand.localPosition;
        startdragX = Input.mousePosition.x;
    }
    public void StopDragHand()
    {
        drag = false;
    }
}