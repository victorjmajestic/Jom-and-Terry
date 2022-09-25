using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private GameObject taskGO = null;
    [SerializeField] private Canvas canvas;
    public GameObject draggedObject;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public bool deleteAfterDrop = false;
    public bool deleteAfterAnyDrop = false;
    public bool marked = false;


    private void Awake(){
        rectTransform = GetComponent<RectTransform>(); 
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData){
        //Debug.Log("OnBeginDrag");
        canvasGroup.alpha = 0.6f; 
        canvasGroup.blocksRaycasts = false;         
    }

    public void OnDrag(PointerEventData eventData){
        //Debug.Log("OnDrag"); //called every frame while object gets dragged
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor / transform.parent.GetComponent<RectTransform>().localScale.x; //movement delta (amount moved per frame)
    }


    public void OnEndDrag(PointerEventData eventData){
        //Debug.Log("OnEndDrag");
        if(taskGO != null)
        {
            Task task = taskGO.GetComponent<Task>();
            task.dragCompleted(this);
        }
        if (deleteAfterAnyDrop)
            Destroy(this.gameObject);
        canvasGroup.alpha = 1f; 
        canvasGroup.blocksRaycasts = true;         
    }

    public void OnPointerDown(PointerEventData eventData){
        //Debug.Log("OnPointerDown");         
    }
}
