using UnityEngine;
namespace TRNTH
{
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
}
