using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class KitchenTasks : MonoBehaviour, Task
{
    [SerializeField] private Image checkbox1;
    [SerializeField] private Image checkbox2;
    [SerializeField] private Sprite checkedSprite;
    
    private bool task1Done = false;
    private bool task2Done = false;
    private Interactable interactable;
    private int plateCount = 0;
    private bool checkedTask = false;
    private bool finishedAllTasks = false;

    public void dragCompleted(DragDrop dropped)
    {
        if (!dropped.marked)
        {
            plateCount++;
            dropped.marked = true;
        }
        
        if(plateCount >= 5)
        {
            if (checkbox1 != null)
                checkbox1.sprite = checkedSprite;
            task1Done = true;
        }
    }
    
    public void dropCompleted()
    {

    }

    public void setInteractable(Interactable newInteractable)
    {
        interactable = newInteractable;
    }

    public void endMinigame()
    {
       int completeness = 0;
        if (task1Done && !task2Done && !checkedTask && !finishedAllTasks) //quits after doing task 1 only
        {
            completeness++;
            Data.score = Data.score + (10 * Data.multiplier);
            checkedTask = true;
        }
        else if (!task1Done && task2Done && !checkedTask && !finishedAllTasks) //quits after doing task 2 only
        {
                completeness++;
                Data.score = Data.score + (10 * Data.multiplier);
                checkedTask = true;
        }
        else if (task1Done && task2Done && !checkedTask && !finishedAllTasks) //quits after doing both tasks
        {
                completeness = completeness + 2;
                Data.score = Data.score + (20 * Data.multiplier);
                finishedAllTasks = true;
        }
        else if (task1Done && task2Done && checkedTask && !finishedAllTasks) //quits after finishing a task after doing the other previously
        {
                completeness++;
                Data.score = Data.score + (10 * Data.multiplier);
                finishedAllTasks = true;
        }
        interactable.minigameEnded(completeness);
    }

    public void sinkDone()
    {
        if (checkbox2 != null)
            checkbox2.sprite = checkedSprite;
        task2Done = true;
    }

 /*   public void resetGame()
    {
        checkedTask = false;
        finishedAllTasks = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    } */
}
