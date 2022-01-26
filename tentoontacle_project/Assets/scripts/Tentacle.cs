using System;
using System.Collections;
using System.Collections.Generic;
using Leap.Unity.Interaction;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    [SerializeField] private GameManager gmManager;

    private float selfDestructionTime = 2f;
    private float howLongAmIOnScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        gmManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //howLongAmIOnScreen += 1 * Time.deltaTime;
        /*if (howLongAmIOnScreen >= selfDestructionTime)
        {
            Destroy(gameObject);
            howLongAmIOnScreen = 0;
        } */
        if (gmManager.IsGameOver == true)
        {
            Destroy(gameObject);
        }
    }
    

    public void TentacleHit()
    {
        print("I got hit");
        Destroy(gameObject);
        gmManager.Score += 1;
    }
}
