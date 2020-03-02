using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    bool isPlush = false;
    [SerializeField]
    int offset = 90;

    bool creepyShake = false;

    public void Update()
    {
        if(isPlush == true)
        {
            this.transform.localRotation = Quaternion.LookRotation(player.position - this.transform.position, Vector3.up);
            this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y - offset, this.transform.localEulerAngles.z);
        }
        else if (creepyShake == false)
        {
            this.transform.localRotation = Quaternion.LookRotation(player.position - this.transform.position, Vector3.up);
            this.transform.localEulerAngles = new Vector3(-this.transform.localEulerAngles.x, -this.transform.localEulerAngles.y - offset, this.transform.localEulerAngles.z);
        }
        else
            this.transform.localEulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
    }

    public void CreepyShake()
    {
        creepyShake = true;
    }
}
