using UnityEngine;
using UnityEngine.UI;

public class FocusProgressBar : MonoBehaviour
{
    public Text numbers;
    public RectTransform line;
    void Start()
    {

    }

    public void SetData(float data)
    {
        print("numbers was=" + numbers.text);
        numbers.text = data.ToString() + "/100";
        line.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left,15, 294 * (data / 100));
        print("numbers  now=" + numbers.text);
    }

    public void SetTimeString(float seconds)
    {

        int min = (int)(seconds / 60);
        int sec = (int)(seconds - min * 60);
        numbers.text = min + ":" + sec+"/2:00";
        line.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 15, 294*(seconds/120));
    }
}