using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
public class AudioConductor : MonoBehaviour
{
	//This is determined by the song you're trying to sync up to
	public SongPlaylist playlist;
	public AudioClip clip;
	public float songBpm;
	public float timeBeforeStart;

	//The number of seconds for each song beat
	public float secPerBeat;

	//Current song position, in seconds
	public float songPosition;

	//Current song position, in beats
	public float songPositionInBeats;
	float previousBeat;

	//How many seconds have passed since the song started = time the song start
	public double dspSongTime;

	//an AudioSource attached to this GameObject that will play the music.
	public AudioSource musicSource;
	public GameEvent OnNewBeat;
	public bool playOnAwake;
	public bool isPlaying;
	public bool isPaused;
	public GameEvent OnMusicStop;

    // Start is called before the first frame update
    void Start()
	{
		// Debug.Log(AudioSettings.dspTime);
		if (playOnAwake)
			Init();
	}

	void GetSongInfo()
	{
		songBpm = playlist.CurrentSong.songBpm;
		timeBeforeStart =playlist.CurrentSong.timeBeforeStart;
		clip = playlist.CurrentSong.clip;
	}
	public void Init()
	{
		Debug.Log(AudioSettings.dspTime);
		GetSongInfo();
		isPlaying = true;
		secPerBeat = 60f / songBpm;
		dspSongTime = AudioSettings.dspTime + timeBeforeStart;
		previousBeat = 0f;
		if (musicSource != null)
		{
			// musicSource.PlayScheduled(dspSongTime + secPerBeat*4f);
			musicSource.clip = clip;
			musicSource.PlayDelayed(secPerBeat * 4f);
			// Debug.Log(secPerBeat*4f);
			musicSource.Play();
		}
		Debug.Log(AudioSettings.dspTime);
	}

	public void Pause()
	{
		isPlaying = false;
		musicSource.Stop();
	}

	// Update is called once per frame
	void Update()
    {
		if (Time.timeScale == 0f) return;
		if (!isPlaying) return;
		if (!musicSource.isPlaying)
		{
			OnMusicStop.Raise();
			return;
		}
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);
		songPositionInBeats = songPosition/secPerBeat;
		if (Mathf.FloorToInt(songPositionInBeats) > Mathf.FloorToInt(previousBeat))
		{
			// Debug.Log("Song position: " + songPosition);
			// Debug.Log("Time on source: " + musicSource.time);
			float delta = (songPosition-musicSource.time);
			float realDelta = secPerBeat*4f - timeBeforeStart;
			// Debug.Log("Time difference: " + delta);
			// Debug.Log("Beat difference: " + realDelta);
			float d = delta - realDelta;
			Debug.Log("Delay: " + d);

			if (OnNewBeat != null)
			{
				OnNewBeat.Raise();
			}
		} 
		previousBeat = songPositionInBeats;
    }
}
