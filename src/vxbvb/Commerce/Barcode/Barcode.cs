using Concepts.Ring1;
using Concepts.Ring2;
using Starcounter;
using System;

namespace Concepts.Ring2
{
	/// <summary>
	/// A barcode contains a code (a string containing text or numbers) in a specific format (Barcode.Kind).
	/// Examples for formats (derived classes from Barcode.Kind) are EAN and Barcode39.
    /// TODO:Henrik, Wordnet map are wrong
	/// </summary>
	public class Barcode : Identifier
	{
		#region Kind class
		/// <summary>
		/// 
		/// </summary>
        public new class Kind : Identifier.Kind 
        {
            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="identifies"></param>
            /// <param name="code"></param>
            /// <param name="validateCode"></param>
            /// <returns></returns>
            public T Assure<T>(Something identifies, string code, bool validateCode) where T : Barcode
            {
                T barcode = null;
                bool isValidCode = true;

                if (validateCode)
                {
                    isValidCode = IsValid(code);
                }
                if (isValidCode)
                {
                    barcode = base.Assure<T>(identifies, code);
                }
                return barcode;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="identifies"></param>
            /// <param name="identifier"></param>
            /// <returns></returns>
            public override T Assure<T>(Something identifies, string identifier)
            {
                if (IsValid(identifier))
                {
                    return base.Assure<T>(identifies, identifier);
                }
                return null;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="identifies"></param>
            /// <param name="code"></param>
            /// <param name="validateCode"></param>
            /// <returns></returns>
            public T New<T>(Something identifies, string code, bool validateCode) where T : Barcode
            {
                T barcode = null;
                bool isValidCode = true;

                if (validateCode)
                {
                    isValidCode = IsValid(code);
                }
                if (isValidCode)
                {
                    barcode = New<T>(identifies, code);
                }
                return barcode;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="identifies"></param>
            /// <param name="identifier"></param>
            /// <returns></returns>
            public override T New<T>(Something identifies, string identifier)
            {
                if (IsValid(identifier))
                {
                    return base.New<T>(identifies, identifier);
                }
                return null;
            }

            /// <summary>
            /// Determines if the barcodes is valid or not (default true).
            /// </summary>
            /// <param name="code">Barcode</param>
            /// <returns>If barcode is valid or not</returns>
            public virtual bool IsValid(string code)
            {
                return true;
            }
        }
		#endregion

		/// <summary>
		/// The barcode data (the number or string) including the checksum.
		/// </summary>
        [SynonymousTo("Name")]
		public string Code;

        
	}
}
