using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlateformScripts : MonoBehaviour
{
    
    [SerializeField] float moveSpeed = 2f;
   [SerializeField] float maxY = 6f;

    private float leftRightMoveSpeed =1.5f;

    public bool leftMovingPlateform, rightMovingPlateform, isBreakble, isSpike, isPlateform;

    private Animator anim;

    private void Awake()
    {
        if(isBreakble)
        {
            anim = GetComponent<Animator>();
        }
    }

    
    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        Vector2 temp = transform.position;
        temp.y += moveSpeed * Time.deltaTime;
        transform.position = temp;

        if(temp.y >= maxY)
        {
            gameObject.SetActive(false);
        }
    }

    void BreakableDeactive()
    {
        Invoke("DeactiveGameObj",0.6f);
    }

    void DeactiveGameObj()
    {
        SoundManagerScript.instance.IceBreakSound();
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            if (isSpike)
            {
                target.transform.position = new Vector2(1000f, 1000f);
                SoundManagerScript.instance.GameOverSound();
                GameManagerScript.instance.RestartGame();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Player")
        {
            if (isBreakble)
            {
                SoundManagerScript.instance.LandSound();
                anim.Play("breakable");
            }

            if (isPlateform)
            {
                SoundManagerScript.instance.LandSound();
            }
        }
    }


    void OnCollisionStay2D(Collision2D target)
    {
        if(target.gameObject.tag == "Player")
        {
            if (leftMovingPlateform)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-leftRightMoveSpeed);
            }

            if (rightMovingPlateform)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(leftRightMoveSpeed);
            }
        }
    }

}
