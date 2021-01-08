using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public int force;
    Rigidbody2D rigid;

    AudioSource audio;
    public AudioClip hitSound;

    GameObject clone1, clone2;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        rigid = GetComponent<Rigidbody2D>();

        Vector2 arah = new Vector2(Arah.arah, 0).normalized;
        rigid.AddForce(arah * force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "TepiKanan")
        {
            Score.scoreP1 += 1;
            Score.HitungScore();
            Score.TampilkanScore();
            ResetBall();
            Vector2 arah = new Vector2(2, 0).normalized;
            rigid.AddForce(arah * force);
        }
        if (coll.gameObject.name == "TepiKiri")
        {
            Score.scoreP2 += 1;
            Score.HitungScore();
            Score.TampilkanScore();
            ResetBall();
            Vector2 arah = new Vector2(-2, 0).normalized;
            rigid.AddForce(arah * force);
        }
        if (coll.gameObject.name == "Pemukul1")
        {
            audio.PlayOneShot(hitSound);
            float sudut = (transform.position.y - coll.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
            rigid.velocity = new Vector2(0, 0);
            rigid.AddForce(arah * force * 2);
            Arah.arah = 2;
        }
        if(coll.gameObject.name == "Pemukul2")
        {
            audio.PlayOneShot(hitSound);
            float sudut = (transform.position.y - coll.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
            rigid.velocity = new Vector2(0, 0);
            rigid.AddForce(arah * force * 2);
            Arah.arah = -2;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("powerup"))
        {
            clone1 = Instantiate(GameObject.FindGameObjectWithTag("bola"));
            clone1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            clone1.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5f).normalized * force);
            clone2 = Instantiate(GameObject.FindGameObjectWithTag("bola"));
            clone2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            clone2.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -5f).normalized * force);

            Destroy(GameObject.FindGameObjectWithTag("powerup"));
            PowerupController.powerUpReady = false;
            PowerupController.waktuTerakhir = Time.fixedTime;
        }
    }
    void ResetBall()
    {
        if (GameObject.FindGameObjectsWithTag("bola").Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(GameObject.FindGameObjectWithTag("powerup"));
            PowerupController.powerUpReady = false;
            PowerupController.waktuTerakhir = Time.fixedTime;

            transform.localPosition = new Vector2(0, 0);
            rigid.velocity = new Vector2(0, 0);
        }
    }
}
