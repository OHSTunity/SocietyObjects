/*
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/Project/TunityProjectEventInfo.cs#4 $
      $DateTime: 2009/11/26 13:39:19 $
      $Change: 27500 $
      $Author: davros $
      =========================================================
*/

using System;
using System.Collections.Generic;
using Concepts.Ring1;
using Concepts.Ring2;
using Concepts.Ring4;
using Concepts.Ring8.Tunity;
using Starcounter;


namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class VersionedSomething : Something
    {
        
        public VersionedSomething()
        {
            _versionNumber = 1;
        }

        private ulong _versionNumber;
        public ulong VersionNumber
        {
            get { return _versionNumber; }
        }

        /// Internal, use VersionCollection.ChangeVersionNumber instead
        /// </summary>
        /// <param name="number"></param>
        internal void SetVersionNumber(ulong number)
        {
            _versionNumber = number;
        }

        private VersionCollection _versionCollection;
        
        [SynonymousTo("_versionCollection")]
        public readonly VersionCollection VersionCollection;
        
        /// <summary>
        /// Internal, you should use VersionCollection.Add instead 
        /// </summary>
        /// <param name="collection"></param>
        internal void SetVersionCollection(VersionCollection collection)
        {
            _versionCollection = collection;
        }


        public virtual T NewVersion<T>() where T : VersionedSomething
        {
            /*Todo:
            T newVersion = InstantiatedFrom.New() as T;
            AddVersion(newVersion);
            return newVersion;
             */
            return default(T);
        }

        public virtual ulong AddVersion(VersionedSomething something)
        {
            if (_versionCollection == null)
            {
                _versionCollection = new VersionCollection();
                _versionCollection.Add(this);
            }
            _versionCollection.Add(something);
            return something.VersionNumber;
        }
        
        public IEnumerable<T> AllVersions<T>() where T: VersionedSomething
        {
            if (_versionCollection != null)
            {
                return _versionCollection.Versions as IEnumerable<T>;
            }
            else
            {
                return new VersionedSomething[] { this } as IEnumerable<T>; 
            }
        }

        public T GetVersion<T>(ulong versionNumber) where T : VersionedSomething
        {
            if (_versionCollection != null)
            {
                return _versionCollection.GetVersion(versionNumber) as T;
            }
            else if (versionNumber == 1)
            {
                return this as T;
            }
            else
            {
                return null;
            }
        }

        public T LastVersion<T>() where T : VersionedSomething
        {
            if (_versionCollection != null)
            {
                return _versionCollection.Last as T;
            }
            else
            {
                return this as T;
            }
        }

        public Boolean Latest
        {
            get
            {
                if (_versionCollection != null)
                {
                    return (_versionCollection.Count == VersionNumber);
                }
                else
                {
                    return true;
                }
            }
        }

        public Boolean IsVersionOf(VersionedSomething version)
        {
            if (_versionCollection != null)
            {
                return _versionCollection.Contains(version);
            }
            return false;
        }

        /// <summary>
        /// Delete this and all versions of this
        /// </summary>
        public void DeleteAll()
        {
            if (_versionCollection != null)
            {
                List<VersionedSomething> list = new List<VersionedSomething>(_versionCollection.Versions);
                list.ForEach(delegate(VersionedSomething something)
                {
                    something.Delete();
                });
            }
            else
            {
                this.Delete();
            }
        }

        /// <summary>
        /// Remove the VersionCollection if this is the only version
        /// </summary>        
        protected override void OnDelete()
        {
            if (_versionCollection != null)
            {
                if (_versionCollection.Count >= 2)
                {
                    _versionCollection.Delete();
                }
                else
                {
                    _versionCollection.Remove(this);
                }
            }
            base.OnDelete();
        }
    }
}
