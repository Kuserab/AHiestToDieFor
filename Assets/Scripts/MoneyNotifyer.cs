﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoneyNotifyer : MonoBehaviour
{
    private GlobalEventManager gem;

    public float amount;

    private void Awake()
    {
        List<MonoBehaviour> deps = new List<MonoBehaviour>
        {
            (gem = FindObjectOfType(typeof(GlobalEventManager)) as GlobalEventManager),
        };
        if (deps.Contains(null))
        {
            throw new Exception("Could not find dependency");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Debug.Log("Touched money!: " + other.transform.name);
            gem.TriggerEvent("AddMoneyToRobber", other.gameObject, new List<object> { amount });
            Destroy(gameObject);
        }
    }
}
