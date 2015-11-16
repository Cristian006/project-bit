using UnityEngine;
using System.Collections;

public abstract class Equipment : MonoBehaviour {


	public bool broken { get{ return false; } }

	public abstract void Fix();
	public abstract void TakeDamage(int damage);
	public abstract void Upgrade();
}
