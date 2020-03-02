using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dools : MonoBehaviour
{
    public GameObject EyeRight;
    public GameObject EyeLeft;
    public Color ColorA;
    public Color ColorB;
    public Vector3 ScaleMax;
    public float SpeedLerpColor;
    public float SpeedLerp;
    public bool Gigantisme;
    Vector3 _startScale;

    // Start is called before the first frame update
    private void Start()
    {
        _startScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        EyeLeft.gameObject.GetComponent<Renderer>().material.SetColor("_Color",Color.Lerp(ColorA, ColorB, SpeedLerpColor *Time.time));
        EyeRight.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp(ColorA, ColorB, SpeedLerpColor *Time.time));

        if (Gigantisme)
            transform.localScale = Vector3.Lerp(_startScale, ScaleMax, SpeedLerp * Time.time);
    }


    //public void  Gigantisme()
    //{
    //    transform.
    //}
}
