using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    Collider2D collider2D;
    GameObject[] bola;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject);
        collider2D = GetComponent<Collider2D>();
        bola = GameObject.FindGameObjectsWithTag("bola");
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("collider_trigger"))
        {
            foreach (GameObject bol in bola)
            {
                bol.GetComponent<CircleCollider2D>().enabled = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("collider_trigger"))
        {
            foreach (GameObject bol in bola)
            {
                bol.GetComponent<CircleCollider2D>().enabled = true;
            }
        }
    }
}
