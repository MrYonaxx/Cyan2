using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public DoorButton DoorButton;
    public Animator AnimationOpen;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AnimationOpen.SetBool("IsOpen", DoorButton.isActived);
       
    }

}
