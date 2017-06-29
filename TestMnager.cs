using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH{
	public class TestMnager : MonoBehaviour {
		[SerializeField]int CopyTimes=1000;
		[SerializeField]GameObject ToCopy;
		[SerializeField]Transform Parent;
		[SerializeField]float Noise=1;
		[ContextMenu("Copy")]
		void Copy(){
			for(var i=0;i<CopyTimes;i++){
				var go=Instantiate(ToCopy);
				go.transform.SetParent(Parent);
				go.transform.localPosition=Random.insideUnitSphere*Noise;
			}
		}
		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}
}