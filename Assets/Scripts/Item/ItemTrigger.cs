using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemTrigger : MonoBehaviour {

    public Weapon weapon;
    public Transform inventorySlots;
    public GameObject InventoryPanel;
    public int inventoryMaxAmount;
    public Inventory inventory;


	// Use this for initialization
	void Start () {
        weapon = GameObject.Find("ItemDatabase").GetComponent<ItemDatabase>().RandomNewWeapon();
        inventorySlots = GameObject.Find("Player").GetComponent<PlayerController>().inventorySlots.transform;
        inventoryMaxAmount = GameObject.Find("Player").GetComponent<PlayerController>().inventoryMaxAmount;
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
        if(other.tag == "Player"){
            if (inventorySlots.childCount 
                - inventory.spaceSlots.Count <
                inventoryMaxAmount)
            {
                AddInventroy();
                Destroy(gameObject);
            }
        }
	}

    private void AddInventroy(){
        //ifインベントリに空きスロットがあるか調べ
        if (FindSpace().Count > 0)
        {
            //空きスロットを取得してcontentをSet
            foreach (var slot in inventory.spaceSlots)
            {
                NewContentAndSet(slot);
                break;
            }
        }
        else
        {
            NewSlotAndContent();
        }
    }
    public List<Transform> FindSpace(){
        inventory.spaceSlots.Clear();
        var length = inventorySlots.childCount;
        //GameObject[] space = new GameObject[length];
        for (int i = 0; i < length; i++){
            //Canvas slot content(Image)
            if (!inventorySlots.GetChild(i).HasChild())
            {
                //space[i] = inventorySlots.GetChild(i).gameObject;
                inventory.spaceSlots.Add(inventorySlots.GetChild(i));
            }
        }

        return inventory.spaceSlots;
    }


    /// <summary>
    /// スロットの作成
    /// </summary>
    /// <returns>The slot.</returns>
    public GameObject NewSlot(){
        var slot = new GameObject("Slot");
        slot.AddComponent<RectTransform>();
        slot.AddComponent<CanvasRenderer>();
        slot.AddComponent<DropObject>();
        slot.AddComponent<Image>().color = new Color(1f, 0.8365f, 0f, 0.3921f);
        return slot;
    }

 
    /// <summary>
    /// アイテムアイコンの作成
    /// </summary>
    /// <returns>The content.</returns>
    public GameObject NewContent(){
        var content = new GameObject(weapon.name);
        content.AddComponent<RectTransform>().sizeDelta = new Vector2(60f, 60f);
        content.AddComponent<CanvasRenderer>();
        content.AddComponent<Image>();
        content.AddComponent<DraggableUI>();
        content.AddComponent<ItemParam>().weapon = this.weapon;
        content.GetComponent<Image>().sprite = this.weapon.itemIcon;
        content.transform.SetAsLastSibling();
        return content;
    }

    /// <summary>
    /// 空いてる枠があるとき、空いてる枠を利用してアイテムアイコンを作成する関数
    /// </summary>
    public void NewContentAndSet(Transform slot)
    {
        var obj = NewContent();
        obj.transform.SetParent(slot);
        obj.GetComponent<RectTransform>().localScale = new Vector3(0.9f,0.9f,0.9f);
        obj.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 0f);

    }
    /// <summary>
    /// インベントリスロットにスロット枠がないけどインベントリ容量に上限を超えてないとき、枠を作ってコンテンツを作成する関数
    /// </summary>
    public void NewSlotAndContent()
    {
        var newSlot = NewSlot();
        newSlot.transform.SetParent(inventorySlots);
        NewContent().transform.SetParent(newSlot.transform);
    }
}
