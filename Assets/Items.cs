using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Items : MonoBehaviour
{
    public static GameObject player;
    public GameObject key;
    public GameObject shifter;
    public GameObject door;
    //public GameObject trigger;
    //public GameObject platformShift;
    public GameObject[] platforms;
    public LayerMask lm;
    bool hasKey = false;
    bool shifted = false;
    bool gameOver = false;
    public static float speed;
    Transform t;
    // Start is called before the first frame update
    void Start()
    {
        key = GameObject.FindGameObjectWithTag("key");
        shifter = GameObject.FindGameObjectWithTag("shifter");
        door = GameObject.FindGameObjectWithTag("lock");
        speed = Controls.maxSpeed;
        //player =  GameObject.FindGameObjectWithTag("Player");
       // obj =  GetComponent<GameObject>();
        //trigger =  GameObject.FindGameObjectWithTag("trigger");
        //hasKey = false;
        platforms = GameObject.FindGameObjectsWithTag("platformShift"); 
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == true) {
            speed = 0f;
            SceneManager.LoadScene (sceneName: "GameOverScene");
        }
        if (key.activeSelf == false) hasKey = true;
        if (shifter.activeSelf == false) shifted = true;
        //Debug.Log(shifted + "\n" + hasKey);
    }
    private void OnTriggerEnter2D(Collider2D trigger) {
        //shifter logic
        if (player && shifter)
        {
            Debug.Log("Time to get funky" + " " + shifted);
            foreach (GameObject platform in platforms)
            {
                platform.transform.Rotate(0, 0, 10);
            }
        }
        //key logic
        if (player && key)
        {
            Debug.Log("Key picked up");
            if (shifted == true)
            {
                foreach (GameObject platform in platforms)
                {
                    platform.transform.Rotate(0, 0, 0);
                }
            }
        }
        if (player && door && hasKey == true) {
            gameOver = true;
        }
    }
    private void OnTriggerExit2D(Collider2D KeyTrigger) {
       gameObject.SetActive(false);
    }
}
