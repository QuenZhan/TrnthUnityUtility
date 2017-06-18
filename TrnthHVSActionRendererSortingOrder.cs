using UnityEngine;
using System.Collections;

public class TrnthHVSActionRendererSortingOrder : TrnthHVSAction {
	[SerializeField]Renderer Renderer;
	[SerializeField]int Order;
	protected override void _execute ()
	{
		base._execute ();
		Renderer.sortingOrder=Order;
	}
}
