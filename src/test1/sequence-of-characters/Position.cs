using System;

namespace test1
{
	public class Position : IPosition
	{
		int offset;
		public Position (int off)
		{
			this.offset = off;
		}

		#region IPosition implementation

		int IPosition.Offset {
			get {
				return offset;
			}
		}

		#endregion
	}
}

