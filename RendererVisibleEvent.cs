using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH{
	public interface IRendererVisibleHandler{
		void BecameVisible();
		void BecameInvisible();
	}
}
namespace TRNTH.Components{
	[RequireComponent(typeof(Renderer))]
	public class RendererVisibleEvent : MonoBehaviour {
		public IRendererVisibleHandler Delegate;
		void OnBecameVisible()
		{
			Delegate.BecameVisible();
		}
		void OnBecameInvisible()
		{
			Delegate.BecameInvisible();
		}
	}
}
