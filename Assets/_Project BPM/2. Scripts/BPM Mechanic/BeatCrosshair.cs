using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class BeatCrosshair : MonoBehaviour
{
	public AudioConductor conductor;
	[Header("Crosshair template")]
	public RectTransform crosshairCenter;
	public RectTransform crosshairLeft;
	public RectTransform crosshairLeftMini;
	public RectTransform crosshairRight;
	public RectTransform crosshairRightMini;
	public RectTransform spawnPointLeft;
	public RectTransform spawnPointRight;
	public float startDspTime;

	public float currentDspTime;
	public float nextDspTime;
	int toggleOffBeet = 0;

    // Start is called before the first frame update
    void Start()
    {
        startDspTime = (float)conductor.dspSongTime;
		StartCoroutine(CR_StartSpawnCrosshair(conductor.secPerBeat));
    }

	void SpawnCrosshair(RectTransform crosshairPrefab, Transform spawnPoint)
	{
		RectTransform newCrosshair = Instantiate(crosshairPrefab, spawnPoint.position, spawnPoint.rotation, transform);
		newCrosshair.transform.DOMove(crosshairCenter.position, 1f).SetEase(Ease.Linear);
		newCrosshair.GetComponent<Image>().DOFade(1f, 0.4f).From(0f);
		Destroy(newCrosshair.gameObject, 1f);
	}

	IEnumerator CR_StartSpawnCrosshair(float interval)
	{
		nextDspTime = startDspTime + interval;
		while(true)
		{
			currentDspTime = (float)AudioSettings.dspTime;
			if (currentDspTime >= nextDspTime)
			{
				SpawnCrosshairBothSide();
				nextDspTime += interval;
			}
			yield return null;
		}
	}

	private void SpawnCrosshairBothSide()
	{
		if (toggleOffBeet == 1)
		{
			SpawnCrosshair(crosshairLeftMini, spawnPointLeft);
			SpawnCrosshair(crosshairRightMini, spawnPointRight);
		}
		else
		{
			SpawnCrosshair(crosshairLeft, spawnPointLeft);
			SpawnCrosshair(crosshairRight, spawnPointRight);
		}
		toggleOffBeet = 1 - toggleOffBeet;
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
