/*
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/DigitalContents/Document.cs#7 $
      $DateTime: 2009/11/26 13:39:19 $
      $Change: 27500 $
      $Author: davros $
      =========================================================
*/

using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;
using Concepts.Ring3.SystemX;
using Concepts.Ring4;
using Starcounter;

namespace Concepts.Ring8.Tunity
{
    public class Document : Something, IModificationTarget, IObjectState
    {
       
        
        public Document()
        {
            ObjectState = ObjectState.Active;
        }

        public Document(Something owner)
        {
            if (owner != null)
            {
                DocumentOwner d = new DocumentOwner(owner, this);
            }
            ObjectState = ObjectState.Active;
        }


        /// <summary>
        /// Does document includes a todo
        /// </summary>
        public Todo Todo;

        
        
        /// <summary>
        /// The name of the document.
        /// </summary>
        [Obsolete("Use the Name property instead")]
        public String DocumentName;

        /// <summary>
        /// OBSOLETE, replaced by ordinary relations
        /// The event this document is connected to.
        /// </summary>
        [System.Obsolete("Replaced by DocumentOwner object, use GetOwner, AddOwne, RemoveOwner")]
        public ProjectEvent Owner;



        private ObjectState _objectState;

        public ObjectState ObjectState
        {
            get
            {
                return _objectState;
            }
            set
            {
                _objectState = value;
                if (Todo != null)
                {
                    Todo.ObjectState = value;
                }
            }
        }

        public Boolean Active
        {
            get
            {
                return ObjectState == ObjectState.Active;
            }
        }

        public Boolean Archived
        {
            get
            {
                return ObjectState == ObjectState.Archived;
            }
        }

        public Boolean Removed
        {
            get
            {
                return ObjectState == ObjectState.Removed;
            }
        }



        /// <summary>
        /// This is the thing to use in order to get the owner
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetOwner<T>() where T:Something
        {
            return this.ImplicitlyRelatedObject<T, DocumentOwner>();
        }

        /// <summary>
        /// This is the thing to use in order to get the owner
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> GetOwners<T>() where T : Something
        {
            return this.ImplicitlyRelatedObjects<T, DocumentOwner>();
        }

        public Boolean HasOwner(Something owner)
        {
            return this.ImplicitRelationTo<DocumentOwner>(owner) != null;
        }

        public DocumentOwner AddOwner(Something owner)
        {
            return new DocumentOwner(owner, this);
        }

        public Boolean RemoveOwner(Something owner)
        {
            DocumentOwner relation = this.ImplicitRelationTo<DocumentOwner>(owner);
            if (relation != null)
            {
                relation.Delete();
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// This is the name of the folder containing files to this document
        /// Its usually the objectID of the first aktivity related to this document
        /// </summary>
        public String FolderName;

        /// <summary>
        /// The creator of the Document.
        /// </summary>
        public Person Creator;

        /// <summary>
        /// Holds status for the file.
        /// </summary>
        public String DocumentStatus;

        /// <summary>
        /// SystemUser that have locked the document. If != null the file is locked otherwise its opened.
        /// </summary>
        public SystemUser LockedBy;
        
        /// <summary>
        /// List of the versions connectd to this document
        /// </summary>
        public IEnumerable<Version> Versions
        {
            get
            {
                return Db.SQL<Version>("SELECT a FROM Version a WHERE a.Owner=?", this);
            }
        }

        /// <summary>
        /// Return latest version
        /// (This is to fasten loading of lists)
        /// </summary>
        public Version LatestVersion;

        /// <summary>
        /// Creates a new version and returns the new Version object
        /// Version.Created = now
        /// Version.Owner = this doc
        /// Version.VersionNumber= 1 higher than the last one
        /// Version.LatestVersion = this version
        /// </summary>
        /// <returns></returns>
        public Version CreateNewVersion()
        {
            Version newVersion = new Version();
            newVersion.Created = DateTime.Now;
            newVersion.LatestUpdated = newVersion.Created;
            newVersion.Owner = this;
            if (LatestVersion == null)
            {
                newVersion.VersionNumber = 1;
            }
            else
            {
                newVersion.VersionNumber = LatestVersion.VersionNumber + 1;
            }
            LatestVersion = newVersion;
            return newVersion;
        }

        /// <summary>
        /// Returns all comments for this document
        /// </summary>
        /// <param name="includePerformed"></param>
        /// <returns></returns>
        public List<Comment> GetComments(Boolean includePerformed)
        {
            List<Comment> comments = new List<Comment>();
            foreach (Version version in Versions)
            {
                foreach (Comment comment in version.Comments)
                {
                    if (includePerformed || comment.Performed)
                    {
                        comments.Add(comment);
                    }
                }
            }
            return comments;
        }

        public Boolean IsCopy()
        {
            return (this.Role<DocumentCopyRelation>() != null);
        }

        public Version GetOriginalVersion()
        {
            Version res = null;
            foreach (Version version in RelatedObjects<Version, DocumentCopyRelation>())
            {
                if (res == null)
                {
                    res = version;
                }
                else if (res.VersionNumber > version.VersionNumber)
                {
                    res = version;
                }
            }
            return res;
        }

        public Version GetOriginalVersion(Version copy)
        {
            Version res = null;
            foreach (DocumentCopyRelation dcr in Roles<DocumentCopyRelation>())
            {
                if (dcr.Destination != null && dcr.Destination != copy)
                    continue;
                if (res == null)
                {
                    res = dcr.Source;
                }
                else if (res.VersionNumber > dcr.Source.VersionNumber)
                {
                    res = dcr.Source;
                }
            }
            return res;
        }

        public IEnumerable<Modification> Modifications
        {
            get
            {
                return this.RelatedObjects<Modification, ModificationTarget>();
            }
        }

        private DateTime _latestUpdated;
        public DateTime LatestUpdated
        {
            get { return _latestUpdated; }
            set { _latestUpdated = value; }
        }

        private Modification _latestModification;
        public Modification LatestModification
        {
            get { return _latestModification; }
            set { _latestModification = value; }
        }

        public void ModificationAdded(Modification mod)
        {
            if (mod.Time > _latestUpdated)
            {
                _latestUpdated = mod.Time;
                _latestModification = mod;
            }
            
            foreach (Something owner in this.GetOwners<Something>())
            {
                if (owner is IModificationTarget)
                {
                    mod.AddTarget(owner);
                }
            }
        }

        public void ModificationRemoved(Modification mod)
        {
            DateTime time = DateTime.MinValue;
            foreach (Modification mods in Modifications)
            {
                if (mods.Time > time)
                {
                    time = mods.Time;        
                }
            }
            if (time > DateTime.MinValue)
            {
                LatestUpdated = time;
            }
            if (_latestModification == mod)
            {
                _latestModification = null;
            }
        }

        /// <summary>
        /// Remove the versions connected to this document.
        /// </summary>        
        protected override void OnDelete()
        {
            base.OnDelete();
            IEnumerable<Version> verToRemove = this.Versions;
            foreach (Version ver in verToRemove)
            {
                ver.Delete();
            }

            foreach (DocumentCopyRelation rel in this.Roles<DocumentCopyRelation>())
            {
                rel.Delete();
            }

            foreach (DocumentOwner docO in this.ImplicitRoles<DocumentOwner>())
            {
                docO.Delete();
            }
            foreach (Modification modification in Modifications)
            {
                modification.RemoveTarget(this);
            }
        }

    }
}
