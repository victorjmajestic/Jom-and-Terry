using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DiningTasks : MonoBehaviour, Task
{
    [SerializeField] private Image checkbox1;
    [SerializeField] private Image checkbox2;
    [SerializeField] private Sprite checkedSprite;

    private Interactable interactable;
    private int frameCount = 0;

    private int chairFlipCount = 0; 
    private bool task1Done = false;
    private bool task2Done = false;
    private bool checkedTask = false;
    private bool finishedAllTasks = false;

     public void setInteractable(Interactable newInteractable)
    {
        interactable = newInteractable;
    }

    public void chairsFlipped(){
        chairFlipCount++;
        if(chairFlipCount >= 2){
            task1Done = true;
                if (checkbox1 != null){
                    checkbox1.sprite = checkedSprite;
            }
        }
    }

    public void framesScratched(){
        frameCount++;
        if(frameCount >= 3){
            task2Done = true;
            if (checkbox2 != null)
                checkbox2.sprite = checkedSprite;
        }
    }

      public void dropCompleted()
    {

    }

     public void dragCompleted(DragDrop dropped)
    {

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

    void start()
    {

    }

    void update()
    {

    }

}
