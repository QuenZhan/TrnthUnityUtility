using UnityEngine;
using System.Collections;

public interface ITrnthAttack {
	Vector3 worldOrigin{get;}
	float damage{get;}
	float knockback{get;}
	bool showDamage{get;}
}
