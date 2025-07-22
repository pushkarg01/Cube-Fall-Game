using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    [SerializeField] float minX = -2.45f, maxX = 2.45f, minY = -5.6f;

    private bool outOfBound;
    
    void Update()
    {
        CheckBound();
    }

    void CheckBound()
    {
        Vector2 temp = transform.position;
        if (temp.x > maxX)
        {
            temp.x = maxX;
        }

        if (temp.x < minX)
        { temp.x = minX; }

        transform.position = temp;

        if (temp.y <= minY)
        {
            if (!outOfBound)
            {
                outOfBound = true;

                SoundManagerScript.instance.DeathSound();
                GameManagerScript.instance.RestartGame();
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Spike")
        {
            transform.position = new Vector2(1000f, 1000f);
            SoundManagerScript.instance.DeathSound();
            GameManagerScript.instance.RestartGame();
        }
    }
}
