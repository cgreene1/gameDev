using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyBehavior : MonoBehaviour
{
    public static GameObject enemy;
    public static GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = Items.player;
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        SceneManager.LoadScene(0);
    }
}
