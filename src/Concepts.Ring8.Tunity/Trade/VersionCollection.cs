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
    public class VersionCollection : Something
    {
        public VersionCollection()
        {
            _versionCount = 0;
        }

        public IEnumerable<VersionedSomething> Versions
        {
            get
            {
                return Db.SQL<VersionedSomething>("SELECT a FROM VersionedSomething a WHERE a.VersionCollection=?", this);
            }
        }


        public VersionedSomething Last
        {
            get
            {
                return GetVersion(Count);
            }
        }

        public VersionedSomething First
        {
            get
            {
                return GetVersion(1);
            }
        }


        private ulong _versionCount;
        public ulong Count
        {
            get
            {
                return _versionCount;
            }
        }

        public Boolean Contains(VersionedSomething version)
        {
            foreach (VersionedSomething something in Versions)
            {
                if (something == version)
                {
                    return true;
                }
            }
            return false;
        }


        public ulong Add(VersionedSomething version)
        {
            _versionCount++;
            version.SetVersionCollection(this);
            version.SetVersionNumber(_versionCount);
            return _versionCount;
        }

        public VersionedSomething GetVersion(ulong index)
        {
            if ((index > Count) || (index == 0))
            {
                return null;
            }
            foreach (VersionedSomething something in Versions)
            {
                if (something.VersionNumber == index)
                {
                    return something;
                }
            }
            return null;
        }

        public void Remove(VersionedSomething version)
        {
            if (Contains(version))
            {
                foreach (VersionedSomething something in Versions)
                {
                    if (something.VersionNumber > version.VersionNumber)
                    {
                        something.SetVersionNumber(something.VersionNumber - 1);
                    }
                }
                version.SetVersionNumber(0);
                version.SetVersionCollection(null);
                _versionCount--;
            }
        }

        protected override void OnDelete()
        {
            foreach (VersionedSomething version in Versions)
            {
                version.SetVersionNumber(0);
                version.SetVersionCollection(null);
            }
            base.OnDelete();
        }

    }
}
