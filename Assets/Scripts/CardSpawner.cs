using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSpawner : MonoBehaviour
{
    private GameObject spawnPoint1;
    private GameObject spawnPoint2;
    private GameObject spawnPoint3;
    private GameObject spawnPoint4;
    private GameObject spawnPoint5;
    private GameObject spawnPoint6;
    private GameObject spawnPoint7;
    private GameObject spawnPoint8;
    private GameObject spawnPoint9;
    public Level sampleLevel;

    // Use this for initialization
    void Start ()
    {
        spawnPoint1 = GameObject.Find("Spawn Point 1");
        spawnPoint2 = GameObject.Find("Spawn Point 2");
        spawnPoint3 = GameObject.Find("Spawn Point 3");
        spawnPoint4 = GameObject.Find("Spawn Point 4");
        spawnPoint5 = GameObject.Find("Spawn Point 5");
        spawnPoint6 = GameObject.Find("Spawn Point 6");
        spawnPoint7 = GameObject.Find("Spawn Point 7");
        spawnPoint8 = GameObject.Find("Spawn Point 8");
        spawnPoint9 = GameObject.Find("Spawn Point 9");

        GameObject card = Card.Summon(sampleLevel.cardsToBeSpawned[0]);
        card.transform.SetParent(spawnPoint1.transform, false);

        GameObject card2 = Card.Summon(sampleLevel.cardsToBeSpawned[1]);
        card2.transform.SetParent(spawnPoint2.transform, false);

        GameObject card3 = Card.Summon(sampleLevel.cardsToBeSpawned[2]);
        card3.transform.SetParent(spawnPoint3.transform, false);

        GameObject card4 = Card.Summon(sampleLevel.cardsToBeSpawned[3]);
        card4.transform.SetParent(spawnPoint4.transform, false);

        GameObject card5 = Card.Summon(sampleLevel.cardsToBeSpawned[4]);
        card5.transform.SetParent(spawnPoint5.transform, false);

        GameObject card6 = Card.Summon(sampleLevel.cardsToBeSpawned[5]);
        card6.transform.SetParent(spawnPoint6.transform, false);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
