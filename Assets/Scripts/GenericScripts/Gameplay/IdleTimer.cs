using UnityEngine;
using System.Collections;

public class IdleTimer : MonoBehaviour {
	public float idleSeconds;

	public float currentTime = 1.0f;

	// Use this for initialization
	void Start () {
		StartCoroutine("StartTimer");
	}

	public void ResetTimer() {
		currentTime = 1.0f;
	}

	IEnumerator StartTimer() {
        while(true) { 
	
         	if(currentTime == idleSeconds)
         		Application.LoadLevel("MainMenu");

         	currentTime++;

            yield return new WaitForSeconds(1f);	
        }
    }
}
