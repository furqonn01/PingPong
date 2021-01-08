using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    public GameObject game;
    public static bool powerUpReady = false;
    public static float waktuTerakhir = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Time.fixedTime != 0)
        {
            if(waktuTerakhir == 0)
            {
                if (Time.fixedTime == 5)
                {
                    if (!powerUpReady)
                    {
                        Instantiate(game);
                        powerUpReady = true;
                    }
                }
            }
            else
            {
                if ((int)Time.fixedTime == (int)(waktuTerakhir + 5))
                {
                    if (!powerUpReady)
                    {
                        Instantiate(game);
                        powerUpReady = true;
                    }
                }
            }
        }
    }

    
}
