using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField]
    private bool isOpen = false;
    [SerializeField]
    private bool isLocked = false;

    [SerializeField]
    private string interactionName = "[E] - Ouvrir";

    [SerializeField]
    private string animatorBoolName = "IsOpen";


    public Animator AnimationOpen;
    public AudioSource AudioSource;
    public AudioClip AudioClipOpen;
    public AudioClip AudioClipClose;

    // Start is called before the first frame update
    void Start()
    {
        AnimationOpen.SetBool(animatorBoolName, isOpen);
    }


    public void OpenDoor(bool b)
    {
        isOpen = b;
        AnimationOpen.SetBool(animatorBoolName, isOpen);
        if (AudioSource != null)
        {
            if (isOpen == true)
                AudioSource.PlayOneShot(AudioClipOpen);
            else if (isOpen == false)
                AudioSource.PlayOneShot(AudioClipClose);
        }
    }

    public void SetLocked(bool b)
    {
        isLocked = b;
    }


    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (isLocked == true)
                {
                    UIManager.Instance.DrawInteraction("Fermé");
                }
                else
                {
                    UIManager.Instance.DrawInteraction("");
                    OpenDoor(!isOpen);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!isOpen)
            {
                UIManager.Instance.DrawInteraction(interactionName);
            }
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UIManager.Instance.DrawInteraction("");
        }
    }

}
