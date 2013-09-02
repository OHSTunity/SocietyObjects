/*
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/DigitalContents/Version.cs#8 $
      $DateTime: 2009/11/26 13:39:19 $
      $Change: 27500 $
      $Author: davros $
      =========================================================
*/

using System;
using Concepts.Ring1;
using Concepts.Ring3.SystemX;
using Starcounter;
using System.Collections.Generic;
using System.Globalization;

namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// Holds a document version.
    /// </summary>
    public class Version : Something, IActivityObject, IModificationTarget
    {
       
        /// <summary>
        /// The verion number
        /// </summary>
        public int VersionNumber;

        /// <summary>
        /// The time this version was created
        /// </summary>
        public DateTime Created;

        /// <summary>
        /// The owner of the version
        /// </summary>
        public Document Owner;

        /// <summary>
        /// The proof if this version has been sent for Proof
        /// </summary>
        public Proof Proof;

        /// <summary>
        /// The files connected to this version
        /// </summary>
        public IEnumerable<VersionDataFile> VersionFiles
        {
            get
            {
                return Db.SQL<VersionDataFile>("SELECT a FROM VersionDataFile a WHERE a.Owner=?", this);
            }
        }
       
        /// <summary>
        /// The comments connected to this version
        /// </summary>
        public IEnumerable<Comment> Comments
        {
            get
            {
                return Comment.GetCommentsFor(this);  
            }
        }

        public TunityActivity ParentActivity()
        {
            if (Owner != null)
            {
                return Owner.GetOwner<TunityActivity>();
            }
            return null;
        }


        public Boolean IncludesFormat(String format)
        {
            foreach (VersionDataFile file in VersionFiles)
            {
                if (file.Name.EndsWith(format, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public VersionDataFile GetFile(String preferredFormat)
        {
            VersionDataFile randomfile = null;
            foreach (VersionDataFile file in VersionFiles)
            {
                randomfile = file;
                if (file.Name.EndsWith(preferredFormat, StringComparison.OrdinalIgnoreCase))
                {
                    return file;
                }
            }
            return randomfile;
        }


        public IEnumerable<Modification> Modifications
        {
            get
            {
                return this.RelatedObjects<Modification, ModificationTarget>();
            }
        }

        public DateTime LatestUpdated;
        public void ModificationAdded(Modification mod)
        {
            LatestUpdated = mod.Time;
            if (Owner != null)
            {
                mod.AddTarget(Owner);
            }
        }

        public void ModificationRemoved(Modification mod)
        {
            if (Owner != null)
            {
                mod.RemoveTarget(Owner);
            }
        }




        /// <summary>
        /// Remove all connected objects if the version is removed.
        /// </summary>
        protected override void OnDelete()
        {
            base.OnDelete();

            foreach (DocumentCopyRelation rel in this.ImplicitRoles<DocumentCopyRelation>())
            {
                rel.Delete();
            }

            foreach (VersionDataFile file in  this.VersionFiles)
            {
                file.Delete();
            }

            foreach (Comment comm in this.Comments)
            {
                comm.Delete();
            }
        }
    }
}
