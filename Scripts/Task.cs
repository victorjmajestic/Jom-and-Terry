using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public interface Task
{
    public void setInteractable(Interactable newInteractable);
    public void dragCompleted(DragDrop dropped);
    public void dropCompleted();
    public void endMinigame();
}
