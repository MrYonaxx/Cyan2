using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public bool isActived = false;
    public GameObject UI_pressKey;
    public AudioSource AudioSource;
    public AudioClip AudioClipOpen;
    public AudioClip AudioClipClose;

    // Start is called before the first frame update
    void Start()
    {
        UI_pressKey.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {

        Debug.Log(other.gameObject.name.ToString());
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                DisplayerSubtitle.Instance.DisplaySubtitle(0, 10);
                if (!isActived)
                {
                    // Debug.Log("WESH");
                    isActived = true;
                    AudioSource.PlayOneShot(AudioClipOpen, .2f);

                }
                else if (isActived)
                {
                    isActived = false;
                    AudioSource.PlayOneShot(AudioClipClose, 0.2f);

                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!isActived)
            {
                UI_pressKey.SetActive(true);
            }
        }
    }



    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            UI_pressKey.SetActive(false);
        }


    }
}
