using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableUI : MonoBehaviour, IPointerClickHandler,IBeginDragHandler , IDragHandler , IEndDragHandler {
    private Transform canvasTran;
    private GameObject draggingObject;
    public Transform prevSlotTransform;
    public bool isOnDragArea = false;
    void Awake()
    {
        canvasTran = GameObject.Find("Canvas").transform;
        prevSlotTransform = transform.parent;
    }

    public void OnPointerClick(PointerEventData pointerEventData){
        Inventory.Instance.lastSelectedContent = pointerEventData.pointerDrag.gameObject;
        Inventory.Instance.lastSelectedSlot = pointerEventData.pointerDrag.transform.GetComponent<RectTransform>().parent.gameObject;
        Inventory.Instance.UpdateUI();
    }

    public void OnBeginDrag(PointerEventData pointerEventData)
    {
        CreateDragObject(this.gameObject);
        draggingObject.transform.position = pointerEventData.position;
    }
    public void OnDrag(PointerEventData pointerEventData)
    {
        draggingObject.transform.position = pointerEventData.position;
        Inventory.Instance.lastSelectedContent = pointerEventData.pointerDrag.gameObject;
        Inventory.Instance.lastSelectedSlot = pointerEventData.pointerDrag.transform.GetComponent<RectTransform>().parent.gameObject;
    }

    public void OnEndDrag(PointerEventData pointerEventData)
    {
        if(!isOnDragArea){
            draggingObject.transform.SetParent(prevSlotTransform);
            draggingObject.GetComponent<RectTransform>().localPosition = Vector3.zero;
        }
        gameObject.GetComponent<Image>().color = Vector4.one;
        Destroy(draggingObject.GetComponent<CanvasGroup>());

    }

    // ドラッグオブジェクト作成
    private void CreateDragObject(GameObject obj)
    {
        draggingObject = obj;
        draggingObject.transform.SetParent(canvasTran);
        draggingObject.transform.SetAsLastSibling();
        draggingObject.transform.localScale = Vector3.one;

        // レイキャストがブロックされないように
        CanvasGroup canvasGroup = draggingObject.AddComponent<CanvasGroup>();
        canvasGroup.blocksRaycasts = false;

        //Image draggingImage = draggingObject.AddComponent<Image>();
        Image sourceImage = GetComponent<Image>();

        //draggingImage.sprite = sourceImage.sprite;
        obj.GetComponent<Image>().rectTransform.sizeDelta = sourceImage.rectTransform.sizeDelta;
        obj.GetComponent<Image>().color = sourceImage.color;
        obj.GetComponent<Image>().material = sourceImage.material;

        gameObject.GetComponent<Image>().color = Vector4.one * 0.6f;
    }
}
