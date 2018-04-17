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
    public interface IMatrix<T>:IReadonlyMatrix<T>{
        new T this[int x,int y]{get;set;}
    }
    public static class MatrixExtension{
        public static string HumanOutput(this IReadonlyMatrix<bool> booleanMatrix){
            // var spit=fromHumanString.Split(seperator);
            // var booleanMatrix=booleanMatrix;
            var lines=new string[booleanMatrix.Height];
            var height=booleanMatrix.Height;
            for (int y = 0; y <height; y++)
            {
                for (int x = 0; x < booleanMatrix.Width; x++)
                {
                    lines[y]+=booleanMatrix[x,height-y-1]?'1':'0';
                }
            }
            return string.Join("\n",lines);
        }
        public static bool TryGetValue<T>(this IReadonlyMatrix<T> matrix,int x,int y,out T value){
            value=default(T);
            if(matrix.IsValid(x,y)){
                value=matrix[x,y];
                return true;
            }
            return false;
        }
        public static bool TrySetValue<T>(this IMatrix<T> matrix,int x,int y,T value){
            if(matrix.IsValid(x,y)){
                matrix[x,y]=value;
                return true;
            }
            return false;
        }
        public static bool IsValid<T>(this IReadonlyMatrix<T> matrix,int x,int y){  
            return x>0 && x<matrix.Width && y>0 && y<matrix.Height;
        }
        public static void CopyTo<T>(this IReadonlyMatrix<T> from,IMatrix<T> to){
            var width=from.Width;
            var height=from.Height;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    to.TrySetValue(x,y,from[x,y]);
                }
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
