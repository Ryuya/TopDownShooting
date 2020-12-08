using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
    public GameObject InventoryPanel;
    public bool isShowInventory = false;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InventoryButton(){
        isShowInventory = !isShowInventory;
        InventoryPanel.SetActive(isShowInventory);

    }
}
