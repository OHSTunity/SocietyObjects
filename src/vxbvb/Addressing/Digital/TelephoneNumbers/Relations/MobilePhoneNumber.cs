namespace Concepts.Ring2
{
    /// <summary>
    /// The role of a telephone number as being someones mobile telephone number.
    /// </summary>
    public class MobilePhoneNumber : TelephoneNumberRelation
	{
		#region Kind class
		/// <summary>
		/// 
		/// </summary>
		public new class Kind : TelephoneNumberRelation.Kind { }
		#endregion
	}
}
