using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;

public class Item : MonoBehaviour
{
    public GameObject player;
    public GameObject obj;
    //public GameObject trigger;
    //public GameObject platformShift;
    public GameObject[] platforms;
    public LayerMask lm;
    bool hasKey = false;
    bool shifted = false;
    Transform t;
    // Start is called before the first frame update
    void Start()
    {
        //player =  GameObject.FindGameObjectWithTag("Player");
       // obj =  GetComponent<GameObject>();
        //trigger =  GameObject.FindGameObjectWithTag("trigger");
        //hasKey = false;
        platforms = GameObject.FindGameObjectsWithTag("platformShift"); 
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(shifted + "\n" + hasKey);
    }
    private void OnTriggerEnter2D(Collider2D trigger) {
        if (player.tag == "Player" && obj.tag == "key")
        {
            hasKey = true;
            Debug.Log("Key picked up");
            if (shifted == true) {
                foreach (GameObject platform in platforms) {
                    platform.transform.Rotate(0,0,0);
                }
            }
        }
        if (player.tag == "Player" && obj.tag == "shifter")
        {
            Debug.Log ("Time to get funky" + " " + shifted);
                foreach (GameObject platform in platforms) {
                    platform.transform.Rotate(0,0,10);
                }
            }
        }
    private void OnTriggerExit2D(Collider2D KeyTrigger) {
        if(obj.tag == "shifter") shifted = true;
        Destroy (gameObject);
        if(obj.tag == "key") hasKey = true;
    }
}
