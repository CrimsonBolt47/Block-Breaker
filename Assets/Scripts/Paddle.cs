using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float minx = 1f; //0th position will be left end of the paddle so the midpart will at 1
    [SerializeField] float maxx = 15f;

    [SerializeField] float screenwidthinunits = 16f;

    //chached referense
    GameStatus thegamesatus;
    Ball theball;
    void Start()
    {
        thegamesatus = FindObjectOfType<GameStatus>();
        theball = FindObjectOfType<Ball>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 paddlePos = new Vector2(mousePosinunits, transform.position.y); vector2 is vector which stores x,y variable. syntax of declaring and initializing is this
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(),minx,maxx);

        transform.position = paddlePos;          //transform is available in inspector and posioton is inside the transform
        //we are modifying the position to the vector paddlepo




    }
    private float GetXPos()
    {
        if(thegamesatus.IsAutoPlayEnabled())
        {
            return theball.transform.position.x;

        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenwidthinunits;
        }
    }
}
