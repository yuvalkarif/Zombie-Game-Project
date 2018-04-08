using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBinds : MonoBehaviour {

	// Use this for initialization
	public Text forward,backward,left,right;
	private Dictionary<string,KeyCode> keys = new Dictionary<string,KeyCode>();
	public Dictionary<string,KeyCode> Keys
	{
		get { return keys; }
		set { keys = value; }
	}

	private Color32 normal = new Color (39, 171, 249, 255);
	private Color32 selected = new Color32 (239, 116, 36, 255);
	private GameObject currentKey; 	
	
	void Awake()
	{
		keys.Add ("Forward", (KeyCode)System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString("Forward", "W")));
		keys.Add ("Backward", (KeyCode)System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString("Backward", "S")));
		keys.Add ("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString("Left", "A")));
		keys.Add ("Right",(KeyCode)System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString("Right", "D")));

		forward.text = keys ["Forward"].ToString();
		backward.text = keys ["Backward"].ToString();
		left.text = keys ["Left"].ToString();
		right.text = keys ["Right"].ToString();
	}
	void Start () {
		
	}

	void update()
	{
		if (Input.GetKeyDown(keys["Forward"])) {
			//Do a move action 
			Debug.Log("up");
		}
	}
	
	// Update is called once per frame
	public void OnGUI()
	{
		Debug.Log ("working");
		if (currentKey != null) {
			Event e = Event.current; 
			if (e.isKey) {
				Debug.Log("Detected key code: " + e.keyCode);
				keys [currentKey.name] = e.keyCode;
				currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
				currentKey.GetComponent<Image> ().color = normal;
				Debug.Log (e.keyCode.ToString ());
				currentKey = null;
			}
		}
	}
	public void ChangeKey(GameObject clicked)
	{
		if (currentKey != null ) {
			currentKey.GetComponent<Image> ().color = normal;
		}
		currentKey = clicked;
		Debug.Log (clicked);
		currentKey.GetComponent<Image>().color = selected;

	
	}
	public void SaveKeys()
	{
		foreach (var key in keys) {
			PlayerPrefs.SetString(key.Key, key.Value.ToString());
		}
		PlayerPrefs.Save ();
	}
	public KeyCode test(string name)
	{
		return keys [name];
	}
}
