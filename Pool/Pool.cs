using System.Collections;
using UnityEngine;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace TRNTH.Pooling
{
	public interface ISpawnee
	{
		void Spawning();
	}
	public interface ILimitedSpawnee:ISpawnee{
		bool IsSpawned{get;set;}
	}
}