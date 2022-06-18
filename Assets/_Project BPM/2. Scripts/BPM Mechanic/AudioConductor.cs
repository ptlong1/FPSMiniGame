using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
public class AudioConductor : MonoBehaviour
{
	//This is determined by the song you're trying to sync up to
	public float songBpm;

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

    // Start is called before the first frame update
    void Awake()
    {
        secPerBeat = 60f/songBpm;
		dspSongTime = AudioSettings.dspTime;
		if (musicSource != null)
			musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);
		songPositionInBeats = songPosition/secPerBeat;
		if (Mathf.FloorToInt(songPositionInBeats) > Mathf.Floor(previousBeat))
		{
			if (OnNewBeat != null)
			{
				OnNewBeat.Raise();
			}
		} 
		previousBeat = songPositionInBeats;
    }
}
