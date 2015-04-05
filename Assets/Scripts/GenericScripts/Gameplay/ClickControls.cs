using UnityEngine;
using System.Collections;

public class ClickControls : MonoBehaviour {

	#region Private Variables
	private float doubleClickStart = -1.0f;
	private bool disableClicks = false;
	private bool _isDragging = false;
	private float doubleClickBuffer = 0.25f;
	private float dragClickStart = -1.0f;
	private float dragClickBuffer = 0.2f;
	#endregion

	#region Standard Methods
	void OnMouseDown() {
		MouseDown();
	}
	
	
	void OnMouseUp() {
		MouseUp();
	}
	#endregion

	#region Public Methods
	public void WatchClicks() {
		WatchForSingleClick();
		WatchForDrag();
	}

	public void MouseDown() {
		HandleDrag();
	}
	
	public void MouseUp() {
		if(!isDragging){
			HandleClick();
		} else {
			OnDragClickUp();
		}
		ResetDragToDefault();
	}
	#endregion

	#region Private Methods
	void HandleClick() {
		if (disableClicks)
			return;
		
		if (doubleClickStart > 0 && (Time.time - doubleClickStart) < doubleClickBuffer && !isDragging) {
			ResetTimerToDefault();
			OnDoubleClick();
			StartCoroutine(lockClicks());
		}
		else {
			doubleClickStart = Time.time;
		}
	}
	
	void HandleDrag() {
		dragClickStart = Time.time;
	}
	
	void WatchForSingleClick() {
		if(doubleClickStart > 0 && Time.time - doubleClickStart > doubleClickBuffer && !isDragging) {
			OnSingleClick();
			ResetTimerToDefault();
		}
	}
	
	void WatchForDrag() {
		if(isDragging) {
			OnDragClickDown();
		} else if(dragClickStart > 0 && Time.time - dragClickStart > dragClickBuffer) {
			isDragging = true;
			OnDragClickDown();
		}
	}

	void ResetTimerToDefault() {
		doubleClickStart = -1.0f;
	}
	
	void ResetDragToDefault() {
		dragClickStart = -1.0f;
		isDragging = false;
	}
	#endregion

	#region Protected Methods
	virtual protected void OnSingleClick() {
	}
	
	virtual protected void OnDoubleClick() {         
	}
	
	virtual protected void OnDragClickDown() {
	}

	virtual protected void OnDragClickUp() {
	}
	#endregion
	
	#region Enumerators
	IEnumerator lockClicks() {
		disableClicks = true;
		yield return new WaitForSeconds(doubleClickBuffer);
		disableClicks = false;
	}
	#endregion

	#region Properties
	public bool isDragging {
		get {
			return _isDragging;
		}
		set {
			_isDragging = value;
		}
	}
	#endregion
}
