using System;
using Ultima;

namespace Server.Bestiary
{
	/// <summary>
	/// Contains beast specific information
	/// </summary>
	public struct BeastInfo
	{
		public readonly string Name;
		public readonly string Background;
		
		public BeastInfo(string name, string background)
		{
			Name = name;
			Background = background;
		}
	};
}