using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteKiRekulle : MonoBehaviour
{
    [SerializeField]
    float speedDoor = 0.1f;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            MoveAway();
        }
    }

    private void MoveAway()
    {
        this.transform.position += new Vector3(speedDoor * Time.deltaTime, 0, 0);
    }
}
