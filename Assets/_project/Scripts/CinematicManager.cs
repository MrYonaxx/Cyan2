using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CinematicData
{
    [SerializeField]
	private int time;	
	public int Time
	{
		get { return time; }
	}

	[SerializeField]
	private UnityEvent unityEvent;
	public UnityEvent UnityEvent
	{
		get { return unityEvent; }
	}

}

public class CinematicManager : MonoBehaviour
{

	[SerializeField]
	private CinematicData[] cinematicData;

    public void PlayCinematic()
    {
		StartCoroutine(CinematicCoroutine());
    }

	private IEnumerator CinematicCoroutine()
	{
		for(int i = 0; i < cinematicData.Length; i++)
		{
			yield return new WaitForSeconds(cinematicData[i].Time);
			cinematicData[i].UnityEvent.Invoke();
		}
	}
}
