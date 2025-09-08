using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptCursor : MonoBehaviour
{
    private SpriteRenderer rend;        //Creates a private sprite render called "rend".
    public Sprite mouseCursor;          //Creates a public sprite called "clickCursor".


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;                   //Cursor is not visible.
        rend = GetComponent<SpriteRenderer>();    //Getting a component from the SpriteRenderer.
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);      //The position of the cursor on the screen. 
        transform.position = cursorPos;           //The sprite will appear on cursors position on the screen.                 

    }
}
