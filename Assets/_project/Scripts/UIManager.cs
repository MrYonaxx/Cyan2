using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textInteraction;

    [Space]
    [Header("Subtitle")]
    [SerializeField]
    private TextMeshProUGUI textSubtitle;
    [SerializeField]
    private float timeTextAppear = 10;
    [SerializeField]
    private float initialTime = 1;
    [SerializeField]
    private float letterTime = 0.1f;

    private IEnumerator subtitleCoroutine;

    [Space]
    [Space]
    [Space]
    [SerializeField]
    private Animator fadeAnimator;





    public static UIManager Instance;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void DrawInteraction(string text)
    {
        textInteraction.text = text;
    }



    public void DrawSubtitle(string sub)
    {
        textSubtitle.text = sub;
        if (subtitleCoroutine != null)
            StopCoroutine(subtitleCoroutine);

        subtitleCoroutine = SubtitleCoroutine();
        StartCoroutine(subtitleCoroutine);
    }

    private IEnumerator SubtitleCoroutine()
    {
        // Initialization
        float time = timeTextAppear;
        Color initialColor = Color.clear;
        Color finalColor = Color.white;

        // Text Appear
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / time;
            textSubtitle.color = Color.Lerp(initialColor, finalColor, t);
            yield return null;
        }

        // Wait
        yield return new WaitForSeconds(initialTime + (letterTime * textSubtitle.text.Length));

        // text Disappear
        t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / time;
            textSubtitle.color = Color.Lerp(finalColor, initialColor, t);
            yield return null;
        }
    }






    public void Fade(bool b)
    {
        fadeAnimator.enabled = true;
        fadeAnimator.SetBool("Fade", b);
    }

}
