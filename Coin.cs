using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Coin : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D other)
    {
        int k = GameControl.Instance.score;
        GameControl.Instance.score += 1;
        GameControl.Instance.Score();
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        Destroy(this.gameObject);

    }

}
