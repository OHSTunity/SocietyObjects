/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring1/Physics/Colour.cs#2 $
      $DateTime: 2012/04/19 21:33:20 $
      $Change: 56975 $
      $Author: hentil $
      =========================================================
*/
/*
 * Society Objects Mark II
 * 
 * Status: Store colour value as a 64 bit integer according to a high dynamic range colour standard.
 *         Remove Assure method. Colour.Kind should be reused and high level (such as Blue), but
 *         colour instance should be a RBG value and should not typically be shared.
 */


using Concepts.Ring1;
using System;
using Starcounter;
using System.ComponentModel;

namespace Concepts.Ring1
{
    /// <summary>
    /// Colour is a visual attribute of things that results from the light they emit or transmit or reflect; "a white color is made up of many different wavelengths of light". A color cannot be instantiated.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Colour is a sensation 
    /// which (in humans) derives from the ability of the fine structure of the 
    /// eye to distinguish three differently filtered analyses of a view. The 
    /// perception of color is influenced by long-term history (nurture) of the 
    /// observer and also by short-term effects such as the colors nearby. The 
    /// term color is also used for the property of objects or light sources that 
    /// can be distinguished by differences in the receptors of the eye.
    /// </para>
    /// <para>
    /// <example>
    /// Use Color.Name to describe the color.
    /// 
    /// Color c = ((Color.Kind) Kind.Of<Color>()).Assure("Blue", "CMYK-code");
    /// </example>
    /// </para>
    /// </remarks>
    /// TODO: Review joawes
    //public class Colour : Something
    //{
    //    #region Kind

    //    /// <summary>
    //    /// The Kind class is a fundamental concept in Society Objects. 
    //    /// Read more about it in the basic introduction to Society Objects.
    //    /// </summary>
    //    public new class Kind : Something.Kind
    //    {
    //        /// <summary>
    //        /// Assures a new color.
    //        /// </summary>
    //        /// <param name="name">English name of color. Example "Blue"</param>
    //        /// <param name="CMYK">CMYK code of color</param>
    //        /// <returns>New Color if current is not existing.</returns>
    //        public Colour Assure(string name, string CMYK)
    //        {
    //            Colour color = AssureByName<Colour>(name);
                    
    //            if (color.IsNew || (CMYK != null))
    //            {
    //                color.CMYK = CMYK;
    //            }

    //            return color;
    //        }
    //    }

    //    #endregion

    //    /// <summary>
    //    /// RGB code for this color. ReadOnly!
    //    /// 
    //    /// <para>
    //    /// Is calculated from the CMYK color code.
    //    /// </para>
    //    /// </summary>
        
    //    public String RGB
    //    {
    //        get
    //        { 
    //            //TODO:
    //            // return ColorTranslator.GetRGBFromCMYK(CMYK);
    //            return null;
    //        }
    //        set
    //        {
    //            //TODO:
    //            // CMYK = ColorTranslator.getCMYKFromRGB(value);
    //        }
    //    }

    //    /// <summary>
    //    /// CMYK code for this color. Not yet implemented.
    //    /// </summary>
    //    //[SynonymousTo("Name")]  Set to synonymous to when CMYK is implemented. Color name will be translated from CMYK code.
    //    public String CMYK
    //    {
    //        get
    //        {
    //            //TODO 
    //            return null;
    //        }
    //        set
    //        {
    //            //TODO
    //        }
    //    }

    //}
}
