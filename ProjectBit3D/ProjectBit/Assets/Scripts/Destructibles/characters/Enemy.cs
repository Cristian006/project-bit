using UnityEngine;
using System.Collections;

public class Enemy : Entity {

	// Use this for initialization
	void Start () {
        stats = new statContainer(statContainer.Entity);
        stats[statContainer.Health, statContainer.Max] = 100;
        stats[statContainer.Health, statContainer.Current] = 100;
    }
}
