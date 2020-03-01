using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayerSubtitle : MonoBehaviour
{
    public List<Subtitle> Subtitles { get; set; } = new List<Subtitle>();
    public static DisplayerSubtitle Instance;
    public TextAsset File;
    public Text TextUI;
     Coroutine CoroutineDisplay;

    public void Awake()
    {
        LoadSubtitle();
    }
    private void Start()
    {
        Instance = Instance ?? this;
       

    }


    public void DisplaySubtitle(int startTo, int endTo)
    {
        if(CoroutineDisplay == null)
            CoroutineDisplay = StartCoroutine(DisplaySubtitleCoro(startTo, endTo));
    }

    public IEnumerator DisplaySubtitleCoro(int startTo, int endTo)
    {
        if (startTo < 0)
            startTo = 0;
        if (endTo >= Subtitles.Count)
            endTo = Subtitles.Count - 1;

        for (int index = startTo; index <= endTo;index ++)
        {
            TextUI.text = Subtitles[index].Text;
            // Text.color = Subtitles[index].Color;
            
           yield return new WaitForSeconds(Subtitles[index].TimeToDisplay);
        }
        TextUI.text = string.Empty;
        CoroutineDisplay = null;
    }

 

    void LoadSubtitle()
    {
        foreach (string line in File.text.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
        {
            string[] data = line.Split(';');
            string textData = string.Empty;

            if (data[0].Contains("."))
            {
                textData = string.Join("\n", data[0].Split('.'));
            }
            else
                textData = data[0];
            Subtitles.Add(new Subtitle(textData, float.Parse(data[1])));
        }
    }
}
