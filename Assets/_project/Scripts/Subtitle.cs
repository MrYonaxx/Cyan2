using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subtitle 
{
    public string Text { get; set; }
    public float TimeToDisplay { get; set; }
    //  public Color Color;

    public Subtitle(string _text, float _time)
    {
        Text = _text;
        TimeToDisplay = _time;
    }
}
