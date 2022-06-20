using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
public class PlaylistController : MonoBehaviour
{
	public SongPlaylist playlist;
	public float timeRest;
	public GameEvent OnSongStop;
	public GameEvent OnSongStart;
	Coroutine currentCR;

	void Start()
	{
		if (OnSongStart != null)
			OnSongStart.Raise();
	}

	public void StopSong()
	{
		if (OnSongStop!= null)
			OnSongStop.Raise();
	}
	
	public void NextSong()
	{
		playlist.Idx++;
	}

	IEnumerator CR_PlaySongAfter(float sec)
	{
		yield return new WaitForSeconds(sec);
		OnSongStart.Raise();
	}

	public void PlayNextSongAfter()
	{
		NextSong();
		if (currentCR !=null)
		{
			StopCoroutine(currentCR);
		}
		currentCR = StartCoroutine(CR_PlaySongAfter(timeRest));
	}
	public void PlayPrevSongAfter()
	{
		playlist.Idx--;
		if (currentCR !=null)
		{
			StopCoroutine(currentCR);
		}
		currentCR = StartCoroutine(CR_PlaySongAfter(timeRest));
	}



}
