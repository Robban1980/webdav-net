using System;

namespace Sphorium.WebDAV.Server.Framework
{
	/// <summary>
	/// WebDav Server Framework Exception.
	/// </summary>
	public class AbortRequest : Exception
	{
		/// <summary>
		/// WebDav Server Framework Exception.
		/// </summary>
		public AbortRequest() { }

		/// <summary>
		/// WebDav Server Framework Exception.
		/// </summary>
		/// <param name="code"></param>
		public AbortRequest(int code) : base(code.ToString()) { }
	}
}
