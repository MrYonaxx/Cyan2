using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventDetection : MonoBehaviour
{
    [SerializeField]
    bool isEventVision = false;
    [SerializeField]
    bool canRepeatTrigger = false;

    [SerializeField]
    UnityEvent unityEvent;

    Transform player;

    IEnumerator coroutineSight = null;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(isEventVision == false)
        {
            if (other.tag == "Player")
            {
                unityEvent.Invoke();
                DesactivateEvent();
            }
        }
        else
        {
            if (other.tag == "Vision")
            {
                player = other.transform.root;
                if (coroutineSight != null)
                    StopCoroutine(coroutineSight);
                coroutineSight = CheckPlayerInSight();
                StartCoroutine(coroutineSight);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Vision")
        {
            if (coroutineSight != null)
                StopCoroutine(coroutineSight);
        }
    }

    private IEnumerator CheckPlayerInSight()
    {
        while (true)
        {
            // On check le Layer 0 voir si on touche le joueur, si on le touche, c'est que c'est bon.
            int layerMask = 1 << 0;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, 20, layerMask))
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.tag == "Player")
                {
                    unityEvent.Invoke();
                    StopCoroutine(coroutineSight);
                    DesactivateEvent();
                }
            }
            yield return null;
        }
    }

    private void DesactivateEvent()
    {
        if (canRepeatTrigger == true)
            return;
        this.gameObject.SetActive(false);
    }


}
