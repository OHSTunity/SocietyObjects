
namespace Concepts.Ring2
{
    /// <summary>
    /// Base class for various URL roles such as home page URL, blog URL etc.
    /// </summary>
    public abstract class HyperLink : AbstractCrossReference
    {
		#region Kind class
		/// <summary>
		/// 
		/// </summary>
        public new class Kind : AbstractCrossReference.Kind { }
		#endregion
	}
}
