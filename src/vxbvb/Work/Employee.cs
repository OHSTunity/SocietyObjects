namespace Concepts.Ring2
{
    /// <summary>
    /// An employee is somebody who is Employeed at a Company or another kind of Organisation.
    /// </summary>
	public class Employee : AffiliatedPerson
	{
		#region Kind class
		/// <summary>
		/// 
		/// </summary>
		public new class Kind : AffiliatedPerson.Kind { }
		#endregion
	}
}
