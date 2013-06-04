using Concepts.Ring1;
using Starcounter;
namespace Concepts.Ring2
{
    /// <summary>
    /// Base class for different roles of a telephone number. Such as fax number, home telephone number, work telephone number etc.
    /// </summary>
    public abstract class TelephoneNumberRelation : AddressRelation
	{
		#region Kind class
		/// <summary>
		/// 
		/// </summary>
		public new class Kind : AddressRelation.Kind { }
		#endregion

        [SynonymousTo("WhatIs")]
        public readonly TelephoneNumber Number;

        public void SetNumber(TelephoneNumber number)
        {
            SetWhatIs(number);
        }
	}
}
