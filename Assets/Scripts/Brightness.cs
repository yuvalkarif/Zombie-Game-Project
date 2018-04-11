using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Brightness : MonoBehaviour
{
    public Slider brightness;
    //public Slider Volume;
    //public Audio BgMusic;
    public GameObject Player_Panel;
    void Start()
    {
        brightness.maxValue = 0.75f;
        brightness.minValue = 0f;
        brightness.value = PlayerPrefs.GetFloat("brightness_Value");
    }
    void Update()
    {
            Player_Panel.GetComponent<Image>().color = new Color(0, 0, 0, (brightness.value));
            PlayerPrefs.SetFloat("brightness_Value", (brightness.value));
      
    }
    public void ResetButton()
    {
        brightness.value = 0;
    }

}