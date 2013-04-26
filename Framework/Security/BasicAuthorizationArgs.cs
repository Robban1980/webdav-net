//-----------------------------------------------------------------------
// <copyright file="BasicAuthorizationArgs.cs" company="Sphorium Technologies">
//     Copyright (c) Sphorium Technologies. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Web;

namespace Sphorium.WebDAV.Server.Framework.Security
{
	/// <summary>
	/// Basic Authorization event arguments
	/// </summary>
	public sealed class BasicAuthorizationArgs : EventArgs
	{

		/// <summary>
		/// Check if an HttpRequest has headers for basic authentication.
		/// </summary>
		/// <param name="header">Request to evaluate</param>
		/// <returns></returns>
		public static bool IsBasicAuthorizationHeader( string header )
		{
			return header != null && header.StartsWith( "Basic" );
		}

		/// <summary>
		/// Basic Authorization event arguments
		/// </summary>
		/// <param name="userName"></param>
		/// <param name="password"></param>
		/// <param name="realm"></param>
		public BasicAuthorizationArgs(string userName, string password, string realm)
		{
			UserName = userName;
			Password = password;
			Realm = realm;
		}

		/// <summary>
		/// Create Basic Authorization arguments given an HttpRequest
		/// </summary>
		/// <param name="header"></param>
		public BasicAuthorizationArgs( string header )
		{
			var decodedBytes = Convert.FromBase64String( header.Substring( 6 ) );
			var authInfo = System.Text.Encoding.ASCII.GetString( decodedBytes ).Split( ':' );

			UserName = authInfo[ 0 ];
			Password = authInfo[ 1 ];
			Realm = string.Empty;
		}

		/// <summary>
		/// User Name
		/// </summary>
		public string UserName { get; private set; }

		/// <summary>
		/// Password
		/// </summary>
		public string Password { get; private set; }

		/// <summary>
		/// Realm
		/// </summary>
		public string Realm { get; private set; }

		/// <summary>
		/// Authorized 
		/// </summary>
		/// <value>
		/// TRUE if the request is authorized
		/// </value>
		public bool Authorized
		{
			get;
			set ;
		}
	}
}
