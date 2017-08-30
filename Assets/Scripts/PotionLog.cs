using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionLog : MonoBehaviour, IConsumable {

    public void Consume()
    {
        Debug.Log("You drank a swig of the potion.");
        Destroy(gameObject);
    }

    public void Consume(StatsCharacter stats)
    {
        Debug.Log("You drank a swig of the potion. Rad!");
        Destroy(gameObject);
    }

}
