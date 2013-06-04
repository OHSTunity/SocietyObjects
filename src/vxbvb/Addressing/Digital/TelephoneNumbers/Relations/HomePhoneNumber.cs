namespace Concepts.Ring2
{
    /// <summary>
    /// The role of a telephone number as a Persons home telephone number.
    /// </summary>
    public class HomePhoneNumber : TelephoneNumberRelation
	{
		#region Kind class
		/// <summary>
		/// 
		/// </summary>
		public new class Kind : TelephoneNumberRelation.Kind { }
		#endregion
	}
}
