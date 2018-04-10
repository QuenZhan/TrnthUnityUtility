namespace TRNTH
{
    public struct Arrows{
		public bool Up;
		public bool Down;
		public bool Right;
		public bool Left;
        public bool AnyKey(){
            return Up || Down || Right ||Left ;
        }
	}
}
