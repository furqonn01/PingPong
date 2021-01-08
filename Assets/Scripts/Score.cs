using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int maxScore = 10;
    public static int scoreP1 = 0;
    public static int scoreP2 = 0;

    static Text scoreUIP1;
    static Text scoreUIP2;
    static Text txPemenang;
    static GameObject panelSelesai;
    // Start is called before the first frame update
    void Start()
    {
        // Matikan music dari DontDestroyOnLoad
        GameObject gameObject = GameObject.Find("Music");
        Destroy(gameObject);

        scoreUIP1 = GameObject.Find("Score1").GetComponent<Text>();
        scoreUIP2 = GameObject.Find("Score2").GetComponent<Text>();

        panelSelesai = GameObject.Find("PanelSelesai");
        panelSelesai.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void HitungScore()
    {
        Debug.Log("Score P1: " + Score.scoreP1 + " Score P2: " + Score.scoreP2);
        scoreUIP1.text = Score.scoreP1 + "";
        scoreUIP2.text = Score.scoreP2 + "";    
    }
    public static void TampilkanScore()
    {
        if (scoreP1 == maxScore)
        {
            panelSelesai.SetActive(true);
            txPemenang = GameObject.Find("Pemenang").GetComponent<Text>();
            txPemenang.text = "Player Biru Pemenang!";
            foreach (GameObject bol in GameObject.FindGameObjectsWithTag("bola"))
            {
                Destroy(bol);
            }
        }
        if (scoreP2 == maxScore)
        {
            panelSelesai.SetActive(true);
            txPemenang = GameObject.Find("Pemenang").GetComponent<Text>();
            txPemenang.text = "Player Merah Pemenang!";
            foreach (GameObject bol in GameObject.FindGameObjectsWithTag("bola"))
            {
                Destroy(bol);
            }
        }
    }
}
