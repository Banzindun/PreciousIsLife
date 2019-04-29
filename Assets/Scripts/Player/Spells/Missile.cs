using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    public Card target;

    public PlayerController player;

    public Spell spell;

    private Tween tween;

    public TweenOptions tweenOptions;

    public void Launch() {
        tween = GetComponent<Tween>();
        tween.Initialize(tweenOptions);

        // We move by local position
        tween.tweenDelegate = ((pos) => transform.position = pos);
        tween.StartVector = transform.position;
        tween.EndVector = target.transform.position;
        tween.enabled = true;
    }


    public void OnTargetReached() {
        spell.MissileHit(target);
       

        // Destroy the missile
        Destroy(gameObject);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
