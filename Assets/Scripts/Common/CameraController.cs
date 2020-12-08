using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject player;
    Vector3 diff;
	// Use this for initialization
	void Start () {
        diff =  transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(player.transform.position.x + diff.x,this.transform.position.y,player.transform.position.z + diff.z);
	}
}
