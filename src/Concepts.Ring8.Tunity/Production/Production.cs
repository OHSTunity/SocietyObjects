/*
 * 
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/Production/Production.cs#4 $
      $DateTime: 2009/10/08 13:14:28 $
      $Change: 25901 $
      $Author: davros $
      =========================================================
*/

using System;
using Starcounter;
using Concepts.Ring1;
using System.Collections.Generic;
using System.Text;


namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// 
    /// </summary>
    public class Production : Something, IObjectState
    {
      
        public Production()
        {
            _objectState = ObjectState.Active;
        }

        private ObjectState _objectState;
        public ObjectState ObjectState
        {
            get { return _objectState; }
            set { _objectState = value; }
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

        //Returns first productiongroup this production is member of
        public ProductionGroup Group
        {
            get
            {
                return this.RelatedObject<ProductionGroup, ProductionGroupMember>();
            }
        }

        public String DSID;
        public String Modified_hash;


        private string _Format;
        public String Format
        {
            get
            {
                return _Format;
            }
            set
            {
                _Format = value;
            }
        }

        private ProductionType _OrderForm;
        public ProductionType OrderForm
        {
            get
            {
                return _OrderForm;
            }
            set
            {
                _OrderForm = value;
            }
        }

        //The campaign this production belongs to
        public Campaign Campaign;
        
        /*
        private Document _document;
        public Document Document
        {
            get { return _document; }
            set { _document = value; }
        }
        */


        private VersionDataFile _file;
        public VersionDataFile File
        {
            get { return _file; }
            set { _file = value; }
        }



        public Document Document
        {

            get { return this.RelatedObject<Document, DocumentOwner>(); }
          
        }

        private VersionDataFile _PrintTemplate;
        public VersionDataFile PrintTemplate
        {
            get
            {
                return _PrintTemplate;
            }
            set
            {
                _PrintTemplate = value;
            }
        }
       
        public IEnumerable<ProductionTemplate> Templates
        {
            get
            {
                return Db.SQL<ProductionTemplate>("SELECT a FROM ProductionTemplate a WHERE a.Owner=?", this);
            }
        }
        
    }

}

