using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Await : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CheckItAsync();
    }

    private async Task CheckItAsync()
    {
        print("let's wait a little");
        await Task.Run(() => { Thread.Sleep(5000); });
        print("Method of Checkit");
    }
}
