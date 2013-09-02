using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring3.SystemX;


namespace Concepts.Ring8.Tunity
{
    
    /// <summary>
    /// ObjectRight store an accessright to a certain object for a certain Group
    /// It has a read and a writeproperty and can also be limited to a certain time frame (With either Start, End or both of them)
    /// </summary>
    public class ObjectRight : Relation
    {
        public ObjectRight()
        {
            _start = DateTime.MinValue;
            _end = DateTime.MinValue;
            _read = false;
            _write = false;
        }

        [SynonymousTo("WhatIs")]
        public readonly Something Object;
        public void SetObject(Something obj)
        {
            SetToWhat(obj);
        }

        /// <summary>
        /// The Production that belongs to a owner
        /// </summary>
        [SynonymousTo("ToWhat")]
        public readonly Group Group;
        public void SetGroup(Group p)
        {
            SetWhatIs(p);
        }


        private Boolean _read;

        public Boolean Read
        {
            get { return _read; }
            set { _read = value; }
        }
        
        private Boolean _write;

        public Boolean Write
        {
            get { return _write; }
            set { _write = value; }
        }

        private DateTime _start;

        public DateTime Start
        {
            get { return _start; }
            set { _start = value; }
        }

        private DateTime _end;

        public DateTime End
        {
            get { return _end; }
            set { _end = value; }
        }
        
        public Boolean Readable
        {
            get 
            {
                DateTime now = DateTime.Now;
                if ((Start != DateTime.MinValue) && (now < Start))
                {
                    return false; 
                }
                else if ((End != DateTime.MinValue) && (now > End))
                {
                    return false;
                }
                else
                {
                    return _read;
                }
            }
        }

        public Boolean Writable
        {
            get
            {
                DateTime now = DateTime.Now;
                if ((Start != DateTime.MinValue) && (now < Start))
                {
                    return false;
                }
                else if ((End != DateTime.MinValue) && (now > End))
                {
                    return false;
                }
                else
                {
                    return _write;
                }
            }
        }

        public void InactivateStart()
        {
            _start = DateTime.MinValue;
        }

        public void InactivateEnd()
        {
            _end = DateTime.MinValue;
        }

     
    }
}

