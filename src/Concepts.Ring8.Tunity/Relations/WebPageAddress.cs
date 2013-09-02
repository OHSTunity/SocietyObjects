#region Using directives

using Concepts.Ring1;
using Concepts.Ring2;
using Starcounter;

#endregion

namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// An web page address. I.e. www.tunity.se.
    /// </summary>
    public class WebPageAddress : DigitalAddress
    {
       

        [SynonymousTo("Name")]
        public string WebPage;
    }
}
