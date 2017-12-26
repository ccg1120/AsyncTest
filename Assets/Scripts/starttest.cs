using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starttest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        uint total = 0;

		for(int i = 0; i < 1000; i++)
        {
            total = total + (uint)i;
            Debug.Log(this.gameObject.name + " :: " + i);
        }

	}
	
	
}
