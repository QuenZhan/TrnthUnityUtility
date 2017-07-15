using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
//using System.IO;
//using UnityEditor;


namespace TRNTH.Terrain{
	public enum BrushState{
		Hover,Paint,EyeDropper,Eraser
	}
	public abstract class TerrainEditor2D: MonoBehaviour {
		[SerializeField]Brush brush;
		[SerializeField]Transform MouseLocator;
		[SerializeField]TextMesh ToolStatus;
		protected virtual void Reset(){
			_tileGameObjects=new List<GameObject>(SizeHorizontal*SizeVertical);
		}
		protected Brush Brush{get{return brush;}}
		protected abstract ReadOnlyCollection<Transform> Transforms{get;}
		protected abstract int SizeHorizontal{get;}
		protected abstract int SizeVertical{get;}
		int GetIndex(Vector3 postion){
//			var scaler=1/GridToWorldPositionScaler;
			var x=Clamp(postion.x,SizeHorizontal);
			var z=Clamp(postion.z,SizeVertical);
			return x+z*SizeHorizontal;
		}
		public int Clamp(float number,int liimation){
			var x=(int)number;
			if(x>=liimation)x=liimation-1;
			if(x<0)x=0;
			return x;
		}
		[SerializeField]Transform _FileGroup;
		public Transform FileGroup{
			get{
				return FileGroup;
			}
		}
		protected abstract ScriptableObject File{get;}
//		protected abstract GameObject GetTileGameObject(int index);
//		protected abstract void SetGameObject(int index,GameObject gameObject);
		protected abstract IList<GameObject> GetPrefabs(string content);
		protected abstract Vector3 GetWorldPosition(int index);
		[SerializeField]List<GameObject> _tileGameObjects;
		public IList<GameObject> TileGameObject{get{return _tileGameObjects;}}

//		protected virtual float GridToWorldPositionScaler{get{return 1;}}
		protected virtual void Paint(int i,bool scan=true){
			var go=_tileGameObjects[i];
			if(go!=null)Destroy(go);
			var prefabs=GetPrefabs(brush.Content);
			if(brush.RandomBrush)brush.RandomIndex=Random.Range(0,100)%prefabs.Count;
			if(prefabs.Count<1)return;
			var prefab=prefabs[brush.RandomIndex%prefabs.Count];
			if(prefab==null)return;
			var instance=Instantiate(prefab);
			instance.transform.position=GetWorldPosition(i);
			_tileGameObjects[i]=instance;
			if(_FileGroup==null){
				_FileGroup=new GameObject(File.name).transform;
			}
			instance.transform.SetParent(_FileGroup);
			if(scan)ScanAstar();
		}
		protected abstract void ScanAstar();
		[ContextMenu("Save")]
		public void Save(){
			UnityEditor.EditorUtility.SetDirty(File);
			UnityEditor.AssetDatabase.SaveAssets();
		}
		protected virtual void Start(){
//			_tileGameObjects=new List<GameObject>(SizeHorizontal*SizeVertical);
			ToolStatus.GetComponent<Renderer>().sortingOrder=1;
			EyeDrop();
			if(_FileGroup==null)Load();
		}
		protected virtual void EyeDrop(int index=0){
			if(brush.Hover!=null && Application.isPlaying){
				Destroy(brush.Hover);
			}
			var prefabs=GetPrefabs(brush.Content);
			if(prefabs.Count<1){
				return;
			}
			var prefab=prefabs[brush.RandomIndex%prefabs.Count];
//			var prefab=prefabs.RandomChooseNonAlloc();
//			if(!brush.RandomBrush)prefab=prefabs[brush.RandomIndex];
			if(prefab==null){
				brush.Hover=MouseLocator.gameObject;
				return;
			}
			if(!Application.isPlaying)return;
			brush.Hover=Instantiate(prefab);
		}
		public virtual Vector3 GridedPosition(Vector3 origin){
			return new Vector3((int)origin.x,(int)origin.y,(int)origin.z);
		}
		BrushState GetStatus(){
			if(Input.GetKey(KeyCode.LeftAlt)){
				return BrushState.EyeDropper;
			}
			if(Input.GetKeyUp(KeyCode.LeftAlt)){
				return BrushState.Paint;
			}
			if(Input.GetKey(KeyCode.E)){
				return BrushState.Eraser;
			}
			if(Input.GetKey(KeyCode.B)){
				return BrushState.Paint;
			}
			return brush.State;
		}
		[ContextMenu("Load")]
		protected virtual void Load(){
			if(File==null){
				throw new System.ArgumentNullException("Fille == null");
			}
			if(_FileGroup!=null)Destroy(_FileGroup.gameObject);
			var size=SizeHorizontal*SizeVertical;
			for(var i=0;i<size;i++){
				EyeDrop(i);
				Paint(i,false);
			}
//			CameraController.SizeX=SizeX;
//			CameraController.SizeZ=SizeZ;
			ScanAstar();
//			var pathGraph=AstarPath;
//			if(AstarPath.active==null)AstarPath.active=pathGraph;
//			if(pathGraph){
//				foreach(var e in pathGraph.graphs){
//					var gridGraph=e as GridGraph;
//					if(gridGraph==null)continue;
//					gridGraph.Width=SizeX;
//					gridGraph.depth=SizeZ;
//					gridGraph.UpdateSizeFromWidthDepth();
//					gridGraph.center=new Vector3(SizeX*0.5f-0.5f,0,SizeZ*0.5f-0.5f);
//				}
//				pathGraph.Scan();
//				UnityEditor.EditorUtility.SetDirty(pathGraph);
//				UnityEditor.AssetDatabase.SaveAssets();
//			}
		}
		void OnDestroy(){
			Save();
		}
		int viewAngle;
		protected abstract int MousePositionToIndex();
		// Update is called once per frame
//		protected abstract Vector3 MouseWorldPosition();
		protected virtual void Update () {
			if(Input.GetKeyDown(KeyCode.F)){
				foreach(var e in Transforms){
					if(e==null)continue;
					var rigid=e.GetComponent<Rigidbody2D>();
					if(rigid!=null)rigid.velocity=Vector2.zero;
					e.position=MouseLocator.transform.position+Vector3.up*2+Random.insideUnitSphere;
				}
			}
			if(Input.GetKey(KeyCode.LeftCommand) && Input.GetKeyDown(KeyCode.R)){
				Load();
			}
			// Get the mouse position from Event.
			// Note that the y position from Event is inverted.
			//			mousePos.x = Input.mousePosition.x;
			//			mousePos.y = Input.mousePosition.y;
			//			var worldPosition=camera.ScreenToWorldPoint(new Vector3(mousePos.x,mousePos.y,c.nearClipPlane));
			//			var ray=new Ray(worldPosition,c.transform.TransformDirection(Vector3.forward));
			//			var camera
			brush.State=GetStatus();
			var size=SizeHorizontal*SizeVertical;
			var index=MousePositionToIndex();
			var postion=GetWorldPosition(index);
			if(index<0 || index>=size)return;
			if(brush.Hover!=null){
				brush.Hover.transform.position=postion;
			}
//			brush.Hover.transform.position=postion;
			MouseLocator.position=postion;
			if(Input.GetMouseButton(0)){
				switch(brush.State){
				case BrushState.Paint:
				case BrushState.Eraser:
					Paint(index);
					break;
				case BrushState.EyeDropper:
					EyeDrop(index);
					break;
				}
			}
			ToolStatus.text=StatusText();
		}
		string StatusText(){
			switch(brush.State){
			case BrushState.Eraser:return Eraser;
			case BrushState.Paint:return PaintTool;
			case BrushState.EyeDropper:return EyeDropper;
			default:return Hover;
			}
			
		}
		const string Eraser="清除";
		const string PaintTool="繪製";
		const string EyeDropper="滴管";
		const string Hover="無";
	}
	[System.Serializable]
	public class Brush{
		public int RandomIndex;
		public bool RandomBrush=true;
		public bool AutoContext=false;
		[EnumFlagsAttribute]
		public TileContext Context;
		public Vector3 Position;
		public string Content;
		public BrushState State;
		public GameObject Hover;
	}
}