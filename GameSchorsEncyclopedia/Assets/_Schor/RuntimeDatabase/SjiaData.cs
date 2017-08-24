using System.Collections;
using System.Collections.Generic;
using TRNTH.SchorsInventory.Component;
using TRNTH.SchorsInventory.DeadDatabase;
using UnityEngine;
namespace TRNTH.SchorsInventory.RuntimeDatabase{
	[CreateAssetMenu]public class SjiaData:ScriptableObject{
		public System.DateTime DateTime{
			get{
				return new System.DateTime(_ticks);
			}
			set{
				_ticks=value.Ticks;
			}
		}
		[SerializeField]long _ticks;
		[SerializeField]public System.TimeSpan Stamina;
		[SerializeField]Item[] _Bag=new Item[10];
		public IList<Item> Bag{get{return _Bag;}}
		public TransportMethod Vehicle;
		public ISet<IPromise> Schedule{get{return null;}}
		public ICollection<IPromise> Credit{get{return null;}}
		public Place Place;
		[SerializeField]Item[] _dock=new Item[10];
		public IList<Item> Dock{get{return _dock;}}
		[SerializeField]List<DeadDatabase.Conversation> _Memories;
		public ISet<DeadDatabase.Conversation> Memories{get{return null;}}
	}
}