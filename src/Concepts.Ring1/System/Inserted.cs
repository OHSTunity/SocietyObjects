
using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;

namespace Concepts.Ring1
{
    public class Inserted : ParticipatingThing
    {

        [SynonymousTo("WhatIs")]
        public readonly Something InsertedObject;
        public void SetInsertedObject(Something insertedObject)
        {
            SetWhatIs(insertedObject);
        }
    }
}
