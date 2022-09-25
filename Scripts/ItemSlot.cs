using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] GameObject newObject;
    [SerializeField] private GameObject taskGO = null;

    public void OnDrop(PointerEventData eventData){
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null){
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            if(eventData.pointerDrag.GetComponent<DragDrop>().deleteAfterDrop)
                eventData.pointerDrag.SetActive(false);
        }

        if(newObject != null){
            newObject.SetActive(true);
            gameObject.SetActive(false);
        }

        if(taskGO != null)
        {
            taskGO.GetComponent<Task>().dropCompleted();
        }
    }
}
