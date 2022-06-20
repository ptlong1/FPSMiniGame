using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class HurtEvent : MonoBehaviour
{
	public RawImage hurtImage;
	public CanvasGroup deadCanvas;
	void Start()
	{
		Health health = GetComponent<Health>();
		health.OnHurt += HurtFX;
		health.OnDie += OnDie;
	}

	void HurtFX()
	{
		hurtImage.gameObject.SetActive(true);
		hurtImage.DOFade(0f, 0.3f).From(0.4f).OnComplete(
			() => {hurtImage.gameObject.SetActive(true);}
		);
	}
	void OnDie()
	{
		GetComponent<FPSController>().enabled = false;
		Cursor.lockState = CursorLockMode.None;
		deadCanvas.gameObject.SetActive(true);
		deadCanvas.DOFade(1f, 2f).From(0f);
	}
	public void ReloadScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
