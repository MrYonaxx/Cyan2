using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField]
    Transform player;

    bool creepyShake = false;

    public void Update()
    {
        if (creepyShake == false)
        {
            this.transform.localRotation = Quaternion.LookRotation(player.position - this.transform.position, Vector3.up);
            this.transform.localEulerAngles = new Vector3(-this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z);
        }
        else
            this.transform.localEulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
    }

    public void CreepyShake()
    {
        creepyShake = true;
    }
}
