using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Health : MonoBehaviour
{

    public int health;
    public int numofhearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    //public Player1 player1;

    //void Start()
    //{
    //    //health = player1.healthcount;
    //    health = GetComponent<Player1>().healthcount;
    //}


    // Update is called once per frame
    void Update()
    {
        health = GetComponent<Player2>().healthcount;

        if (health > numofhearts)
        {
            health = numofhearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numofhearts)
            {
                hearts[i].enabled = true;
            }

            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
