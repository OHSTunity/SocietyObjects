namespace Concepts.Ring2
{
    /// <summary>
    /// A telephone number may play the role as a way to reach a Fax machine.
    /// </summary>
    public class FaxPhoneNumber : TelephoneNumberRelation
	{
		#region Kind class
		/// <summary>
		/// 
		/// </summary>
		public new class Kind : TelephoneNumberRelation.Kind { }
		#endregion
	}
}
