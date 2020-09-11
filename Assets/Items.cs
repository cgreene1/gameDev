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
    bool hasKey = false;
    Transform t;
    // Start is called before the first frame update
    void Start()
    {
        key = GameObject.FindGameObjectWithTag("key");
        shifter = GameObject.FindGameObjectWithTag("shifter");
        door = GameObject.FindGameObjectWithTag("lock");
        platforms = GameObject.FindGameObjectsWithTag("platformShift"); 
    }

    // Update is called once per frame
    void Update()
    {   //end level function
        if (door.activeSelf == false && hasKey == true) {
            SceneManager.LoadScene (sceneName: "GameOverScene");
        }
        //key check
        if (key.activeSelf == false) hasKey = true;
    }
    private void OnTriggerEnter2D(Collider2D trigger) {
        //key check at door
        if (gameObject.tag == "lock" && hasKey == false)
        {
            Debug.Log("No Key!");
        }
        //shifter logic
        else if (gameObject.tag == "shifter")
        {
            Debug.Log("Time to get funky");
            foreach (GameObject platform in platforms)
            {
                platform.transform.Rotate(0, 0, 10);
            }
            gameObject.SetActive(false);
        }
        else if (gameObject.tag == "key")
        {
            Debug.Log("NO MORE FUNK");
            foreach (GameObject platform in platforms)
            {
                platform.transform.Rotate(0, 0, -10);
            }
            gameObject.SetActive(false);
        }
        else if (gameObject.tag == "lock" && hasKey == true)
        {
            SceneManager.LoadScene(sceneName: "GameOverScene");
        }
        //deactivate on entry
        gameObject.SetActive(false);
    } 
}
