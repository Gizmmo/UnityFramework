using UnityEngine;
using System.Collections;

public class ClickMovement : AdvancedBehaviour {

	#region States
	public enum MovementStates { IDLE, MOVING };
	public MovementStates currentState;
	#endregion

	#region Public Variables
	public float speed = 1.5f;
	#endregion

	#region Private Variables
	private Vector3 target;
    	private Vector3 startPosition;
    	private float startTime;
    	private float journeyLength;
	#endregion

	#region Delegates and Events
	public System.Action<GameObject> OnMoving;
	public System.Action<GameObject> OnIdle;
	#endregion

	#region Properties
	public bool IsMoving {
		get {
			return currentState == MovementStates.MOVING;
		}
	}

	public bool IsIdle {
		get {
			return currentState == MovementStates.IDLE;
		}
	}
	#endregion

	void Start() {
        target = transform.position;
    }

    void Update() {
        if(Input.GetMouseButtonDown(1)) {
			MovePlayer();
        }
        
        if(IsMoving) {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(transform.position, target, fracJourney); //Switch transform.position to startPosition for constant move speed
        }
    }

	protected override void ClearEvents() {
		base.ClearEvents();
		OnIdle = null;
		OnMoving = null;
	}

	void MovePlayer() {
		target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z - Camera.main.transform.position.z));
		target.z = transform.position.z;
		startTime = Time.time;
		startPosition = transform.position;
		journeyLength = Vector3.Distance(startPosition, target); //Switch transform.position to startPosition for constant move speed
		TriggerMovingState();
		TurnToPosition();
	}

	void TurnToPosition() {
		transform.LookAt(target);
	}

	void TriggerMovingState() {
		if(OnMoving != null) {
			OnMoving(gameObject);
		} 
	}

	void TriggerIdleState() {
		if(OnIdle != null) {
			OnIdle(gameObject);
		}
	}

}
