using UnityEngine;
using System.Collections;

public class AdvancedBehaviour : MonoBehaviour {

	void OnDisable() {
		ClearEvents();
		ClearHandlers();
	}

	virtual protected void ClearEvents() {

	}

	virtual protected void ClearHandlers() {

	}
}
