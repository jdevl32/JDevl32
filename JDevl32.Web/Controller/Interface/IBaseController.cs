using Microsoft.AspNetCore.Hosting;

namespace JDevl32.Web.Controller.Interface
{

	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IBaseController
	{

#region Property

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IHostingEnvironment HostingEnvironment { get; }

#endregion

	}

}
