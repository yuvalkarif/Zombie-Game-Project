using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour {

	public Transform settingCanvas;
	PauseGame pause;

	public Slider brightnessSlider;
	public bool menu = false;

	public float rgbValue = 0.5f;

	public void openSettings()
	{
		menu = true;
		settingCanvas.gameObject.SetActive(true);
	}
	public void closeSettings()
	{
		menu = false;
		settingCanvas.gameObject.SetActive(false);
	}
	public void onGUI()
	{
		rgbValue /= (float)brightnessSlider.normalizedValue;
		RenderSettings.ambientLight = new Color (rgbValue, rgbValue, rgbValue, 1);
	}

}
