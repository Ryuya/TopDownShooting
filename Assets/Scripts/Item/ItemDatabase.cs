using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {

    public List<Weapon> weapons = new List<Weapon>();
    public List<UniqueParamator> uniques = new List<UniqueParamator>();
	// Use this for initialization
	void Awake () {
        weapons.Add(new Weapon("デバッグ用武器",5,Weapon.ItemType.SMG,Weapon.Rarity.Normal,1000,2000,true,true,"debug",null,0));
        weapons.Add(new Weapon("デバッグ用ユニークA武器", 5, Weapon.ItemType.SMG, Weapon.Rarity.Normal, 1000, 2000, true, true, "debug", null,1));
        weapons.Add(new Weapon("デバッグ用ユニークF武器", 5, Weapon.ItemType.SMG, Weapon.Rarity.Normal, 1000, 2000, true, true, "debug", null, 1));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Weapon RandomNewWeapon(){
        var drop = Random.Range(0,2);
        Weapon weapon = weapons[drop];
        if(drop > 0){
            
        }
        return weapon;
    }
}
