using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : MonoBehaviour {

    public Card TargetCard;

    public Card ActorCard;

    public BoardPlayer Player;

    public GameObject MovingCardCanvas;

    private Transform oldTransformParent;

    private Vector3 originalPosition;

    private Vector3 goal;

    private TweenOptions forwardTweeningOptions;

    private TweenOptions backwardTweeningOptions;

    public void Initialize(AttackBehaviourDefinition def)
    {
        forwardTweeningOptions = def.ForwardTweeningOptions;
        backwardTweeningOptions = def.BackwardTweeningOptions;
    }

    // Use this for initialization
    void Start () {
        originalPosition = transform.position;
        goal = TargetCard.transform.position;

        Tween tween = GetComponent<Tween>();
        tween.Initialize(forwardTweeningOptions);
        tween.EndVector = TargetCard.transform.position; // TODO take the outside of the card
        tween.StartVector = ActorCard.transform.position;
        tween.EndEvent.AddListener(OnTargetReached);
        tween.enabled = true;
        tween.tweenDelegate = (Vector3 position) => transform.position = position;

        oldTransformParent = transform.parent;
        transform.SetParent(MovingCardCanvas.transform, true);
    }
	
    public void OnTargetReached() {
        Debug.Log("Attack target reached!");
        
        // TODO Go just to the side of the card, maybe overlap a bit
        
        // TODO play some attack effect or something
        // TODO play attack sound

        // If I have reached my original spot:
        if (goal == originalPosition)
        {
            transform.SetParent(oldTransformParent, true);

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
            TargetCard.OnBeeingAttacked();
            TargetCard.OnActionDone();

            // Go back
            goal = originalPosition;

            Tween tween = GetComponent<Tween>();
            tween.Initialize(backwardTweeningOptions);
            tween.EndVector = originalPosition;
            tween.StartVector = ActorCard.transform.position;
            tween.EndEvent.AddListener(OnTargetReached);
            tween.enabled = true;
            tween.tweenDelegate = (Vector3 position) => transform.position = position;
        }
    }
}
