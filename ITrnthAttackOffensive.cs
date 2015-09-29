using UnityEngine;
using System.Collections;

public interface ITrnthAttackOffensive {
	float damage{get;}
	float penetration{get;}
	float criticalStrikeChance{get;}
	float criticalStrikeScale{get;}

	IDSTeamMember member{get;}
	
	string control{get;}
	string[] tags{get;}

	Vector3 force{get;}
	bool showDamage{get;}

	Transform tra{get;}
	Vector3 position{get;}
}
