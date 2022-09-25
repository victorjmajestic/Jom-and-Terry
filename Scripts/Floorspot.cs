using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floorspot : MonoBehaviour
{
    private float secondsToClean = 5f;
    private Human human;
    private bool cleaningNow = false;

    public void setHuman(Human newHuman)
    {
        human = newHuman;
        human.addToQueue(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Human maybeHuman = other.gameObject.GetComponent<Human>();
        if (maybeHuman != null)
        {
            if (!human.cleaning)
            {
                human.secondsToClean = secondsToClean;
                human.startCleaning(this.gameObject);
                StartCoroutine(destroySoon());
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!cleaningNow)
        {
            Human maybeHuman = other.gameObject.GetComponent<Human>();
            if (maybeHuman != null)
            {
                if (!human.cleaning)
                {
                    human.secondsToClean = secondsToClean;
                    human.startCleaning(this.gameObject);
                    StartCoroutine(destroySoon());
                }
            }
        }
    }

    private IEnumerator destroySoon()
    {
        yield return new WaitForSeconds(secondsToClean);
        gameObject.SetActive(false);
    }
}
