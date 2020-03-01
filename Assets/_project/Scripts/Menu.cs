using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text Play;
    public Color ColorA;
    public Color ColorB;
    public float SpeedLerp;

    void Awake()
    {
        Play.color = ColorA;
        Debug.Log("Play Color: " + Play.color.ToString() + " - " + ColorA.ToString());
    }

    // Update is called once per frame
    void Update()
    {

        float pingPong = Mathf.PingPong(Time.time / SpeedLerp, 1f); ;
        Color color = Color.Lerp(ColorA, ColorB, pingPong);
        Play.color = color;

    }

    public void LoadLevel(string _name)
    {
        SceneManager.LoadScene(_name);
    }
}
