using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH
{
    [System.Serializable]public struct MatrixIndex{
    /// Start from left - bottom is 0:0 ;
		public int x;
		public int y;
		public MatrixIndex(int x,int y){
			this.x=x;
			this.y=y;
		}
	}
	public interface IReadonlyMatrix<T>
	{
		int Width{get;}
		int Height{get;}
        T this[int x,int y]{get;}
    }
    public abstract class MatrixBase{
        [SerializeField]int _width;
        [SerializeField]int _height;
        public int Width{get{return _width;}}
        public int Height{get{return _height;}}
        protected MatrixBase(int width,int height){
            _width=width;
            _height=height;
        }
    }
    public class ArrayMatrix<T>:MatrixBase
    ,ISerializationCallbackReceiver
    ,IMatrix<T>
    ,INonAllocList<T>
    {
        [SerializeField]MatrixIndex _currentIndex;
        [SerializeField]T _current;
        [SerializeField][HideInInspector]T[] _datas;
        // [SerializeField]T[] _datas;
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
            _current=this[_currentIndex];
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
    public interface IMatrix<T>:IReadonlyMatrix<T>{
        // void ChangeSize(int width,int height);
        new T this[int x,int y]{get;set;}
    }
    public static class MatrixExtension{
        public static void CopyTo<T>(this IReadonlyMatrix<T> from,IMatrix<T> to){
            var length=from.Width*to.Height;
            for (int i = 0; i < length; i++)
            {
                to.SetValue(i,from.GetValue(i));
            }
        }
        public static T GetValue<T>(this IReadonlyMatrix<T> matrix,int byIndex){
            return matrix[byIndex%matrix.Width,byIndex/matrix.Width];
        }
        public static void SetValue<T>(this IMatrix<T> matrix,int byIndex,T value){
            matrix[byIndex%matrix.Width,byIndex/matrix.Width]=value;
        }
        public static T GetValue<T>(this IReadonlyMatrix<T> matrix,MatrixIndex byIndex){
            return matrix[byIndex.x,byIndex.y];
        }
        readonly static System.Text.StringBuilder _stringBuilder=new System.Text.StringBuilder();
        public static string ToHumanString(this IReadonlyMatrix<bool> booleanMatrix){
            var height=booleanMatrix.Height;
            var width=booleanMatrix.Width;
            _stringBuilder.Length=0;
            for (int y = height - 1; y >= 0 ; y--)
            {
                for (int x = 0; x < width; x++)
                {
                    _stringBuilder.Append(booleanMatrix[x,y]?'1':'0');
                }
                _stringBuilder.Append('\n');
            }
            return _stringBuilder.ToString();
        }
    }
}
