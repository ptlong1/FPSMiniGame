using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PrecisionTable", menuName = "ScriptableObjects/PrecisionTable", order = 1)]
public class PrecisionTable :ScriptableObject 
{
	public float[] precisionGroup;
	public string[] titleGroup;
	public Color[] colorGroup;
	public float[] damageMultiplier;
	public int GetPrecisionGroup(float offset, float secPerBeat)
	{
		float precision = 2f*offset/secPerBeat;
		for (int i = 0; i < precisionGroup.Length; ++i)
		{
			if (precision <= precisionGroup[i])
				return i;
		}
		return precisionGroup.Length -1;
	}

}
