using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH{
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
		// T this[MatrixIndex vec]{get;}
        T this[int x,int y]{get;}
    }
	// public class MatrixUtility{
    //     // public IReadOnlyCollection<T> GetDistinct<T>(IReadonlyMatrix<T> matrix){

        // }
        // public static void Copy(IReadonlyMatrix<bool> from, IReadonlyMatrix<bool> to)
        // {
        //     foreach(var e in to){
        //         if(e.x>=from.Width || e.y>=from.Height)continue;
        //         to[e]=from[e];
        //     }
        // }
    }
    public abstract class MatrixBase{
        public int Width{get;private set;}
        public int Height{get;private set;}
        protected MatrixBase(int width,int height){
            this.Width=width;
            this.Height=height;
    }
    public class ArrayMatrix<T>:MatrixBase
    // ,IReadonlyMatrix<T>
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

    // public interface IReadonlyBitMatrix:IReadonlyMatrix<bool>{
    //     // int[] Ints{get;}
    //     // bool IsAnd(IReadonlyBitMatrix other);
    // }
    [System.Serializable]
    public class IntFieledMatrix : MatrixBase
    ,IMatrix<bool>
    ,INonAllocList<int>
    {
        static readonly char[] seperator=new char[]{'\n','\r'};
        public static IntFieledMatrix CreateFrom(string fromHumanString){
            var spit=fromHumanString.Split(seperator);
            var booleanMatrix=new IntFieledMatrix(spit[0].Length,spit.Length);
            for (int y = 0; y < booleanMatrix.Height; y++)
            {
                for (int x = 0; x < booleanMatrix.Width; x++)
                {
                    booleanMatrix[x,y]=spit[y][x]=='1';
                }
            }
            return booleanMatrix;
        }
        [SerializeField]int[] _ints;
        int[] Ints{get{return _ints;}}

        public int Count {get{return _ints.Length;}}

        public int this[int index]
        {
            get
            {
                return _ints[index];
            }

            set
            {
                _ints[index]=value;
            }
        }

        public IntFieledMatrix(int width, int height,bool toggle=false) : base(width, height)
        {
            if(width>30)throw new System.IndexOutOfRangeException(width.ToString());
            _ints=new int[height];
            if(toggle){
                for (int i = 0; i < height; i++)
                {
                    _ints[i]=-1;
                }
            }
        }

        public bool this[MatrixIndex vec] {
             get {
                 return this[vec.x,vec.y];
             }
             set{
                 this[vec.x,vec.y]=value;
             }
             }
        const int FirstOne=1<<30;
        public bool this[int x, int y] {
             get {
                 return (_ints[y] & FirstOne>>x)!=0;
             }
            set{
                  if(value){
                    _ints[y] |= FirstOne>>x;
                  }
                else{
                    _ints[y] &= ~FirstOne>>x;
                }
              }
            }

        public bool IsAnd(IntFieledMatrix other)
        {
            for (int i = 0; i < Height; i++)
            {
                var bit=_ints[i]&other.Ints[i];
                if(bit!=0)return true;
            }
            return false;
        }

        public void SetAll(bool v)
        {
            int value=0;
            if(v)value=-1;
            for (int i = 0; i < Height; i++)
            {
                _ints[i]=value;
            }
        }

        public void Shift(MatrixIndex vec)
        {
            if(vec.x==0 && vec.y==0)return;
            for (int i = Height-vec.y-1; i >=0; i--)
            {
                // else if(vec.x==0)_ints[i+vec.y]=_ints[i];
                _ints[i+vec.y]=_ints[i]>>vec.x;
                if(i<vec.y)_ints[i]=0;
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
    }
}
