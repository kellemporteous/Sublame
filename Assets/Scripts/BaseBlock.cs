﻿using UnityEngine;
using System.Collections;

public class BaseBlock : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public virtual void OnHit(GameObject player, PlayerController controller)
    {

    }
}
