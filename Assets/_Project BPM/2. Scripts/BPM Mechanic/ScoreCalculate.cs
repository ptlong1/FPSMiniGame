using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculate : MonoBehaviour
{
	public AudioConductor conductor;
	[Header("Score Percent")]
	public PrecisionTable precisionTable;
	public PrecisionText precisionText;
	private void Awake() {
		// conductor = GetComponent<AudioConductor>();	
	}
	public void BeatPrecision()
	{
		float pos = conductor.songPositionInBeats;
		float offset =pos - Mathf.Round(conductor.songPositionInBeats);
		// Debug.Log(offset);
		offset = Mathf.Abs(offset);
		int precisionIdx = precisionTable.GetPrecisionGroup(offset, conductor.secPerBeat);
		// Debug.Log(offset);
		// Debug.Log($"Precision: {precisionGroup[precisionIdx]}, Title: {titleGroup[precisionIdx]}");
		precisionText.Trigger(precisionTable.titleGroup[precisionIdx], precisionTable.colorGroup[precisionIdx]);
	}
	
}
