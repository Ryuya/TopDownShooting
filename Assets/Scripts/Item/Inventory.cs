using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
[System.Serializable]
public class Inventory : SingletonMonoBehaviour<Inventory> {
    public Transform inventorySlots;
    public Transform DescriptionPanel;
    public Transform InventoryPanel;

    public List<Transform> spaceSlots = new List<Transform>();

    public List<Weapon> weapons = new List<Weapon>();

    public GameObject lastSelectedContent;
    public GameObject lastSelectedSlot;

    //UI関連
    public Text name;


	public void Start()
	{
        inventorySlots = GameObject.Find("Player").GetComponent<PlayerController>().inventorySlots.transform;
        DescriptionPanel = GameObject.Find("/Canvas/InventoryPanel/SideMenuPanel/DescriptionPanel").transform;
        InventoryPanel = GameObject.Find("/Canvas/InventoryPanel").transform;
        InventoryPanel.gameObject.SetActive(false);
	}

    private void Update()
    {
        // Debug.Log(selectedObject.name);
        CheckSpace();

    }
    public void UpdateUI(){

        if(lastSelectedContent != null){
            var weapon = lastSelectedContent.GetComponent<ItemParam>().weapon;
            //DescriptionPanel.GetChild().GetComponent<Text>().text = lastSelectedContent.GetComponent<ItemParam>().weapon.name;
            NewDescriptionText("名前",weapon.name);
            NewDescriptionText("ダメージ",weapon.damage.ToString());
            NewDescriptionText("ダメージカット率", weapon.damageCut.ToString()+"%");
            NewDescriptionText("カウンター", weapon.counterAmount.ToString());
            NewDescriptionText("クリティカルダメージ", weapon.criticalDamage.ToString());
            NewDescriptionText("クリティカル率", weapon.criticalRate.ToString()+"%");
            NewDescriptionText("ドロップ率", weapon.dropLuck.ToString()+ "%");
            NewDescriptionText("電撃", weapon.electricDamage.ToString());
            NewDescriptionText("炎", weapon.fireDamage.ToString());
            NewDescriptionText("グラビティ", weapon.gatherRange.ToString()+"m");
            NewDescriptionText("HP+", weapon.HealAmmount.ToString());
            NewDescriptionText("HP吸収", weapon.healthAbsorption.ToString());
            NewDescriptionText("貫通率", weapon.penetrationRate.ToString()+ "%");
            NewDescriptionText("リロードタイム", weapon.reloadCoolddown.ToString());
            NewDescriptionText("発射感覚","-"+weapon.rapidFireCooldown.ToString()+"%");
            NewDescriptionText("視野", weapon.light.ToString());
            NewDescriptionText("毒", weapon.poisonDamage.ToString());
            NewDescriptionText("弾薬", weapon.remainingBullets.ToString());
            NewDescriptionText("シード", weapon.seedAmount.ToString());
            NewDescriptionText("ステルス", weapon.stealth.ToString());
            NewDescriptionText("スタン", weapon.stunTime.ToString());
            NewDescriptionText("タイムストップ", weapon.timeStopAmmount.ToString());
            NewDescriptionText("重量", weapon.weight.ToString());
            //選択されたWeaponのパラメータを見ていく。
            //
        }
    }

    public void NewDescriptionText(string paramName,string str){
        var newObj = new GameObject(paramName);
        newObj.AddComponent<Text>().text = paramName + ":"+str;
        //newObj.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        newObj.GetComponent<Text>().color = Color.black;
        newObj.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        newObj.transform.SetParent(DescriptionPanel);
        newObj.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    /// <summary>
    /// 空きスロットの更新
    /// </summary>
    public void CheckSpace(){
        spaceSlots.Clear();
        var length = inventorySlots.childCount;
        //GameObject[] space = new GameObject[length];
        for (int i = 0; i < length; i++)
        {
            //Canvas slot content(Image)
            if (!inventorySlots.GetChild(i).HasChild())
            {
                //space[i] = inventorySlots.GetChild(i).gameObject;
                spaceSlots.Add(inventorySlots.GetChild(i));
            }
        }
    }
}
