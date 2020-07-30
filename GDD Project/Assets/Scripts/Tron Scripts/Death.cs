using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    
    void Update()
    {
        if(player1 == null)
        {
            print("Player lost: " + player1.name);
        }
        else if(player2 == null)
        {
            print("Player lost: " + player2.name);
        }
        else if(player1 == null && player2 == null)
        {
            print("Both Lost");
        }
    }
}
