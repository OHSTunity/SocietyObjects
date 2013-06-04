using System;

namespace Concepts.Ring2
{
    /// <summary>
    /// The Internet and the World Wide Web uses an "Uniform Resource Locator" as a way to 
    /// point to a specific resource such as a web page, a document or any other kind of
    /// digital content.
    /// </summary>
    public class URL : DigitalAddress
    {
		#region Kind class
		/// <summary>
		/// 
		/// </summary>
        public new class Kind : DigitalAddress.Kind { }
		#endregion
	}
}
