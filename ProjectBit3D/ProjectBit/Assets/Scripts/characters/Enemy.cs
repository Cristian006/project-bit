using UnityEngine;
using System.Collections;

public class Enemy : Entity {

	// Use this for initialization
	void Start () {
        stats[Health, Max] = 100;
        stats[Health, Current] = 100;
    }
}
