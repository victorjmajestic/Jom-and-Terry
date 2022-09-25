using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockTable : MonoBehaviour
{
    public Color highlightColor;
    public Color readyColor;
    public Floorspot floorSpot;
    public Human human;
    public GameObject cat;
    public GameObject knockedObject;
    private SpriteRenderer spriteRenderer;
    private bool highlighted = false;
    private bool done = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == cat && !done)
        {
            highlight();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject == cat)
        {
            unhighlight();
        }
    }

    private void highlight()
    {
        spriteRenderer.color = highlightColor;
        highlighted = true;
    }

    private void unhighlight()
    {
        highlighted = false;
        if (done)
        {
            spriteRenderer.color = Color.white;
        }
        else
        {
            spriteRenderer.color = readyColor;
        }
    }

    void OnMouseDown()
    {
        if (highlighted)
        {
            floorSpot.gameObject.SetActive(true);
            floorSpot.setHuman(human);
            done = true;
            unhighlight();
            knockedObject.SetActive(false);
            Data.score = Data.score + 20;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = readyColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
