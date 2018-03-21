
using UnityEngine;
using UnityEngine.UI;

public class StatusIndicator : MonoBehaviour { // A class which controls the UI Of the enemy 
    [SerializeField]
    private RectTransform healthBarRect;
    [SerializeField]
    private Text healthText;

     void Start() // Checks the if the objects are created  
    {
        if (healthBarRect == null)
            Debug.LogError("No health bar refrenced");
        if (healthText == null)
            Debug.LogError("No health bar refrenced");
    }
    public void SetHealth(int _cur, int _max) // Changes the Values which appear in the UI 
    {
        float _value = (float)_cur / _max;
        healthBarRect.localScale = new Vector3(_value, healthBarRect.localScale.y, healthBarRect.localScale.z);
        
        healthText.text = _cur + "/" + _max + " HP";
    }
    
}

