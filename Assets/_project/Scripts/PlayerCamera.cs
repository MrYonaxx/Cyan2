using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    [SerializeField]
    Camera cameraComponent;

    IEnumerator fovCoroutine;



    public void ChangeFOV(float targetFOV)
    {
        ChangeFOV(targetFOV, 60);
    }

    public void ChangeFOV(float targetFOV, int time = 60)
    {
        if (fovCoroutine != null)
            StopCoroutine(fovCoroutine);
        fovCoroutine = FieldOfViewTransition(targetFOV, time);
        StartCoroutine(fovCoroutine);
    }

    private IEnumerator FieldOfViewTransition(float targetFOV, int time)
    {
        time = Mathf.Max(1, time);
        time /= 60;
        float initalFov = cameraComponent.fieldOfView;
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / time;
            cameraComponent.fieldOfView = Mathf.Lerp(initalFov, targetFOV, t);
            yield return null;
        }
        cameraComponent.fieldOfView = targetFOV;
    }

}
