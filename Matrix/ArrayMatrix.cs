using UnityEngine;
namespace TRNTH
{
    public class ArrayMatrix<T>:MatrixBase
    ,ISerializationCallbackReceiver
    ,IMatrix<T>
    ,INonAllocList<T>
    {
        void Set(){
            this[_currentIndex]=_current;
        }
        [SerializeField]MatrixIndex _currentIndex;
        [ContextMenuItem("Set","Set")]
        [SerializeField]T _current;
        [SerializeField][HideInInspector]T[] _datas;
        protected T[] Datas{get{return _datas;}}

        public int Count
        {
            get
            {
                return _datas.Length;
            }
        }

        public ArrayMatrix(int width, int height) : base(width, height)
        {
            _datas=new T[width*height];
        }
        public ArrayMatrix() : this(3, 3)
        {
        }
        void ItemSet(int index,T item){
			_datas[index]=item;
        }

        public void OnBeforeSerialize()
        {
            
            this.TryGetValue(_currentIndex.x,_currentIndex.y,out _current);
        }

        public void OnAfterDeserialize()
        {
            // throw new NotImplementedException();
        }

        public T this[MatrixIndex vec] { 
			get {
				return _datas[vec.x+vec.y*Width];
			}
			set {
                ItemSet(vec.x+vec.y*Width,value);
			}
		}
        public T this[int index]{
            get{return _datas[index];}
            set{
                _datas[index]=value;
            }
        }
        public T this[int x,int y] { 
			get {
				return _datas[x+y*Width];
			}
			set {
                ItemSet(x+y*Width,value);
			}
		}
    }
}
