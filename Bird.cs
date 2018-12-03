using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
    public RigidbodyType2D bodyType;
    public float upforce = 200f;
    public bool IsDead = false;
    public bool IsWin = false;

    private Rigidbody2D rb2d;
    private Animator anim;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (IsDead)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0, upforce));
            anim.SetTrigger("Flap");
            
        }
        if (IsWin)
        {
            bodyType = RigidbodyType2D.Kinematic;
            rb2d.velocity = Vector2.zero;
        }
	}

    void OnTriggerEnter2D(Collider2D cl)
    {

        if(cl.tag == "Ground" || cl.tag == "Column")
        {
            IsDead = true;
            rb2d.velocity = Vector2.zero;
            anim.SetTrigger("Die");
            GameControl.Instance.Die();
            cl.isTrigger = false;
        }


    }
}
