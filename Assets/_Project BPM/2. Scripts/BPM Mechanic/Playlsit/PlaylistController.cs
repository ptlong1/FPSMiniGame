using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
using UnityEngine.InputSystem;
using TMPro;
public class PlaylistController : MonoBehaviour
{
	public SongPlaylist playlist;
	public float timeRest;
	public GameEvent OnSongStop;
	public GameEvent OnSongStart;
	Coroutine currentCR;
	public TMP_Text nameSong;

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
		// OnSongStop.Raise();
		NextSong();
		if (currentCR !=null)
		{
			StopCoroutine(currentCR);
		}
		currentCR = StartCoroutine(CR_PlaySongAfter(timeRest));
	}
	public void PlayPrevSongAfter()
	{
		// OnSongStop.Raise();
		playlist.Idx--;
		if (currentCR !=null)
		{
			StopCoroutine(currentCR);
		}
		currentCR = StartCoroutine(CR_PlaySongAfter(timeRest));
	}

	void Update()
	{
		if (Keyboard.current.qKey.wasPressedThisFrame)
		{
			OnSongStop.Raise();
		}
	}

	public void UpdateSongName()
	{
		nameSong.text = "SONG: " + playlist.CurrentSong.name;
	}

}
