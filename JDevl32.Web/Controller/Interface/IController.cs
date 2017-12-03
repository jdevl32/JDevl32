using Microsoft.AspNetCore.Hosting;

namespace JDevl32.Web.Controller.Interface
{

	/// <summary>
	/// A (web) controller.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IController
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
