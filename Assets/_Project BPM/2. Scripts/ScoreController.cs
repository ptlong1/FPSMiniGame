using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class ScoreController : MonoBehaviour
{
	private int score;
	public TMP_Text text;

	public int Score { get => score; set {
			score = value;
			text.text = "SCORE: " + score.ToString();
			text.GetComponent<RectTransform>().DORewind();
			text.GetComponent<RectTransform>().DOShakeScale(0,2f);
		}}

	void Start()
	{
		Score = 0;
	}
}
