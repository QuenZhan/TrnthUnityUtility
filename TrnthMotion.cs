using UnityEngine;
using System.Collections;

public class TrnthMotion : MonoBehaviour {
	public Animator animator;
	public TrnthCharacterControllerCreature ccc;
	public float delayAnimator;
	public float delayForce;
	public float cooldown;
	public string animatorParameter;
	public Vector3 forceWorld;
	public Vector3 forceLocal;
}
