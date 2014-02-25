using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    float timer = 500;

	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;

	}

    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width - 160, 30, 150, 20), "Timer: " + timer.ToString("0:00"));
    }
}
