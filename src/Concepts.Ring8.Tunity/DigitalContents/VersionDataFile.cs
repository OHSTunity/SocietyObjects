/*
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/DigitalContents/VersionDataFile.cs#6 $
      $DateTime: 2009/11/26 13:39:19 $
      $Change: 27500 $
      $Author: davros $
      =========================================================
*/

using System;
using Concepts.Ring1;
using Concepts.Ring3;
using Concepts.Ring3.SystemX;

namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// A file connected to a specific Version
    /// </summary>
    public class VersionDataFile : DataFile
    {
       
        /// <summary>
        /// The version this file is connected to.
        /// </summary>
        public Version Owner;

        /// <summary>
        /// The person that uploaded this file.
        /// </summary>
        public Person UploadedBy;

        /// <summary>
        /// Last time file was prepared,
        /// applies to pdf files for now (preparePDF)
        /// If not prepared, this value is DateTime.MinValue; 
        /// </summary>
        public DateTime Prepared;


        public String FilePath
        {
            get {
                if (Owner != null && Owner.Owner != null)
                    return Owner.Owner.FolderName + "\\" + Name;
                else
                    return Name;
            }
        
        }


        /*Is no more, wonder what to use instead?
        /// <summary>
        /// Delete physical file when deleting object.  //Add this in SoietyObj instead?
        /// </summary>
        protected override void OnDelete()
        {
            base.OnDelete();

            if (System.IO.File.Exists(this.LocationPath))
            {
                System.IO.File.Delete(this.LocationPath);
            }
        }
         */
    }
}
