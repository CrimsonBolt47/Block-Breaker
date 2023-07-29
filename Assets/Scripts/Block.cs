using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklevfx;
    [SerializeField] Sprite[] hitSprites;
    //cached reference
    Level level;

    //state variables
    [SerializeField] int timesHit;//all of debug purposes


    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>(); //to call functions in level without using serialize and putting script in there
        if (tag == "Breakable")
        {
            level.CountBlocks();//1 block executes this function 1 time,so each no. of blocks function is executed and we get the number of blocks
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)//INBUILT FUNCTION
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }

    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteindex=timesHit-1;
        if (hitSprites[spriteindex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteindex];
        }
        else
            Debug.LogError("block sprite not available"+gameObject.name);
    }

    private void DestroyBlock()
    {
       
        
        PlaySound();
        Destroy(gameObject); //'gameObject' menas the object itself with the script ,'GameObject' is someother object
        level.BlockDestroyed();
        TriggerSparkleVFX();


    }

    private void PlaySound()
    {
        FindObjectOfType<GameStatus>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparkleVFX()
    {
        GameObject sparkles = Instantiate(blockSparklevfx,transform.position,transform.rotation);//instantiate means make
        Destroy(sparkles, 1f);

    }
}
