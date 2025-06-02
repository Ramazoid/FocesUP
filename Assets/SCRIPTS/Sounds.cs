using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public List<AudioClip> clips;
    public AudioSource player;
    public static Sounds IN;

    private void Awake()
    {
        IN = this;
    }


    public static void Play(string clipname)
    {
        AudioClip c = IN.clips.Find((c) => { return c.name == clipname; });
        if (c == null)
            throw new Exception($"there is no sound named[{clipname}]");
        IN.player.ToString();
        IN.player.clip = c;
        IN.player.Play();
    }

    void Start()
    {
        player = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
