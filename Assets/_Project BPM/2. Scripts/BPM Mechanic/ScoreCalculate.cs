using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculate : MonoBehaviour
{
	AudioConductor conductor;

	private void Awake() {
		conductor = GetComponent<AudioConductor>();	
	}
	public void BeatPrecision()
	{
		float pos = conductor.songPositionInBeats;
		float precision =Mathf.Abs(pos - Mathf.Round(conductor.songPositionInBeats));
		Debug.Log(precision);
	}
}
