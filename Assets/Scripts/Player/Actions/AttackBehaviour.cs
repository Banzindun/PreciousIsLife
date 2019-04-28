using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : MonoBehaviour {

    public Card TargetCard;

    public Card ActorCard;

    public BoardPlayer Player;

    private Vector3 originalPosition;

    private Vector3 goal;

    private float speed = 800;

    private int targetReachedConstant = 5;

    private float pauseOnTargetReached = 1;

    private float doNotMoveTime = 0;
    

	// Use this for initialization
	void Start () {
        originalPosition = transform.position;
        goal = TargetCard.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        doNotMoveTime -= Time.deltaTime;
        if (doNotMoveTime > 0)
            return;

        Debug.Log( "Distance " + Vector3.Distance(transform.position, goal));
        if (Vector3.Distance(transform.position, goal) <= targetReachedConstant)
        {
            TargetReached();
        }
        else
        { 
            transform.position = Vector3.MoveTowards(transform.position, goal, speed * Time.deltaTime);
        }
    }

    public void TargetReached() {
        Debug.Log("Attack target reached!");
        doNotMoveTime = pauseOnTargetReached;
        
        // TODO play some attack effect or something
        // TODO play attack sound

        // If I have reached my original spot:
        if (goal == originalPosition)
        {
            // Disable myself
            Destroy(this);

            // Say that the action is over
            // TODO: Maybe again a small delay here
            Player.OnActionDone();
        }
        else
        {
            // Cause the damage
            TargetCard.ReceiveDamage(ActorCard);
            goal = originalPosition;
        }
    }
}
