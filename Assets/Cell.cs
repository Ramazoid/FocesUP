using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    private float scale;
    public Sprite hidden;
    public Sprite open;
    public int n;
    private Image IM;
    internal Action<Cell> Check;
    public bool opened;

    void Start()
    {
        IM = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Press()
    {
        if (!opened)
        {
            scale = 1f;
            StartCoroutine(Flip());
            Sounds.Play("flip");
        }
    }

    public IEnumerator Flip()
    {
        while(scale>-1)
        {
            scale -=0.05f;
            if (scale <= 0)
                IM.sprite = open;
            transform.localScale = new Vector3(scale, 1, 1);
            yield return true;
        }
        opened = true;
        Check(this);

    }

    internal void FlipToHide()
    {
        scale = -1f;
        StartCoroutine(FlipOver());
        //Sounds.Play("flip");
    }
    public IEnumerator FlipOver()
    {
        while (scale < 1)
        {
            scale += 0.05f;
            if (scale >= 0)
                IM.sprite = hidden;
            transform.localScale = new Vector3(scale, 1, 1);
            yield return true;
        }
        opened = false;

    }

    internal void Hide()
    {
        IM.sprite = hidden;
    }
}
