using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropObject : MonoBehaviour, IDropHandler,IPointerEnterHandler, IPointerExitHandler
{
    private GameObject slot;
    private Sprite nowSprite;
    private int counter = 0;
    public GameObject player;
    void Start()
    {
        nowSprite = null;
        slot = this.gameObject;
        player = GameObject.Find("Player");
    }

	void Update()
	{
        Image img = slot.GetComponent<Image>();

        if(Inventory.Instance.lastSelectedSlot == gameObject){
            img.color = new Color(0f,1f,1f,1f);
        } else {
            img.color = new Color(1f,1f,1f,1f);
        }
        if(transform.childCount > 0 && counter > 0){
            Debug.Log("装備更新");
            //パラメーターを0に初期化してEquipmentSlotsの全てのパラメーターを加算する
            player.GetComponent<PlayerController>().InitializedParams();
            player.GetComponent<PlayerController>().UpdateParam();
            counter--;
        }
	}


	public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (pointerEventData.pointerDrag == null || pointerEventData.pointerDrag.tag == "Scroll") {
            return;
        }
        //そのスロットが埋まっていないなら
        if(transform.childCount == 0)
        pointerEventData.pointerDrag.GetComponent<DraggableUI>().isOnDragArea = true;
        GameObject droppedImage = pointerEventData.pointerDrag.gameObject;
        //iconImage = pointerEventData.pointerDrag;
        //iconImage.GetComponent<Image>().sprite = droppedImage.GetComponent<Image>().sprite;
        //iconImage.GetComponent<Image>().color = Vector4.one * 0.6f;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (pointerEventData.pointerDrag == null || pointerEventData.pointerDrag.tag == "Scroll")
        {
            return;
        }
        pointerEventData.pointerDrag.GetComponent<DraggableUI>().isOnDragArea = false;
        //if (pointerEventData.pointerDrag == null) return;
        //iconImage.GetComponent<Image>().sprite = nowSprite;
        //if (nowSprite == null)
        //    iconImage.GetComponent<Image>().color = Vector4.zero;
        //else
            //iconImage.GetComponent<Image>().color = Vector4.one;
    }
    public void OnDrop(PointerEventData pointerEventData)
    {
        if (pointerEventData.pointerDrag == null || pointerEventData.pointerDrag.tag == "Scroll")
        {
            return;
        }
        var pointerDragObject = pointerEventData.pointerDrag;
        if(pointerDragObject.GetComponent<DraggableUI>().isOnDragArea){
            pointerDragObject.transform.SetParent(gameObject.transform);
            gameObject.transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 0f);
            pointerDragObject.GetComponent<DraggableUI>().prevSlotTransform = this.transform;
            counter = 1;
        }

        //iconImage.GetComponent<Image>().color = Vector4.one;
    }
}
