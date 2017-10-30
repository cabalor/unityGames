﻿using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	
	public Sprite[] sprites;

	private int hits;
	private lvlMng Manager;
	private int maxHp;

	
	// Use this for initialization
	void Start () {
		hits = 0;
		Manager = GameObject.FindObjectOfType<lvlMng> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionExit2D(Collision2D collision){
		bool canBeDestroyed = (this.tag == "Breakable");
		if (canBeDestroyed) {
			HitsHandler ();
		}
	}

	void HitsHandler(){
		hits++;
		maxHp = sprites.Length + 1; // maxhp equals number of spritees but we can change it to public and set it mnually
		if (maxHp <= hits) {
			Destroy (gameObject);
		} else {
			LoadSprite();
		}

	}

	void LoadSprite(){
		int arrIndx = hits - 1; // it should give you 0, coude arrays are numberd from 0, and when you want looad a sprite form array you have to begin from start of array.
		if(sprites [arrIndx]){
		this.GetComponent<SpriteRenderer> ().sprite = sprites [arrIndx];  //get component load a component in this case Sprite Renderer which is visible in gui. and this. is Brick, on particular Brick.

		}
	}

	void WinTheGame(){
		Manager.LoadNextLvl ();
	}
	
	//TODO remove Winthegame
}
