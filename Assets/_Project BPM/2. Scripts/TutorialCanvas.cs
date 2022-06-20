using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.InputSystem;
public class TutorialCanvas : MonoBehaviour
{
	public CanvasGroup tutorialGroup;
	public bool isOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.tabKey.wasPressedThisFrame)
		{
			ToggleTutorial();
		}
    }

	void ToggleTutorial()
	{
		if (isOn)
		{
			isOn = false;
			tutorialGroup.DOFade(0f, 0.5f)
				.OnComplete(() => {Time.timeScale =1f;AudioListener.pause = false;})
				.SetUpdate(true);
			tutorialGroup.interactable = false;
			

		}
		else
		{
			isOn = true;
			tutorialGroup.DOFade(1f, 0.5f)
				.OnComplete(() => {Time.timeScale =0f;AudioListener.pause = true;})
				.SetUpdate(true);
			tutorialGroup.DOFade(1f, 0.5f).OnComplete(() => Time.timeScale =0f).SetUpdate(true);
			tutorialGroup.interactable = true;
		}
	}
}
