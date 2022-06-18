using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class PrecisionText : MonoBehaviour
{
	public TMP_Text text;
	public float bounceSec;
	public void Trigger(string title, Color color)
	{
		text.text = title;
		// text.color = color;
		text.DOColor(color, bounceSec/2f);
		text.GetComponent<RectTransform>().DOShakeScale(bounceSec);
		text.GetComponent<RectTransform>().DOShakePosition(bounceSec);
		// text.GetComponent<RectTransform>().DOShakeRotation(bounceSec);
	}
}
