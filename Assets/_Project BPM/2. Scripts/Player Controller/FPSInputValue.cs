using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FPSInputValue", menuName = "ScriptableObjects/FPSInputValue", order = 1)]
public class FPSInputValue : ScriptableObject 
{
	public Vector3 move3;
	public Vector2 move2;
	public Vector2 look;
	public bool jump;
	public bool shoot;
}
