/*
 * 
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/Production/ProductionTemplate.cs#4 $
      $DateTime: 2008/12/16 10:06:38 $
      $Change: 17570 $
      $Author: matake $
      =========================================================
*/

using System;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring3.SystemX;
using System.Collections.Generic;

namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// PDF-template for Productions.
    /// </summary>
    public class ProductionTemplate : Something
    {
        public String TemplateFile;
        public ProductionAdModule AdModule;
        public String Format;
        public Production Owner;

        public ProductionTemplate()
        {
         
        }

        public String TemplatePath
        {
            get { return ""; }//Something.Kind.GetInstance<WarehouseConfiguration.Kind>().TemplateFileDir + "/" + TemplateFile; }
        }

      
        

       
    }


   public enum ProductionAdModule
    {
        Undefined = 0,
        T4 = 1,
        T5 = 2,
        T6 = 3

    }

}