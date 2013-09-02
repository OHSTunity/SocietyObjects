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
    public class Quote : VersionedSomething
    {

        
        public Quote():base()
        {
            Created = DateTime.Today;
            _quoteStatus = QuoteStatus.New;
        //    Conditions = Kind.GetInstance<Quote.Kind>().DefaultConditions;
           // QuoteNumberGenerator.Current().GenerateNew(this);
        }

        [SynonymousTo("Description")]
        public String Conditions;

        [SynonymousTo("Name")]
        public String Header;

        public override T NewVersion<T>()
        {
            Quote newVersion = base.NewVersion<T>() as Quote;
            newVersion.Company = Company;
            newVersion.OurReference = OurReference;
            newVersion.TheirReference = TheirReference;
            newVersion.Name = Name;
            newVersion.Description = Description;
            newVersion.Activity = Activity;

            foreach (QuoteRow row in Rows)
            {
                QuoteRow newRow = row.Clone<QuoteRow>();
                newRow.Quote = newVersion;
            }
            return newVersion as T;
        }


        //Unique quotenumber (counter in db)
        private ulong _quoteNumber;
        public ulong QuoteNumber
        {
            get { return _quoteNumber; }
        }
        public void SetQuoteNumber(ulong value)
        {
            _quoteNumber = value;
        }

        private String _fileName;
        public String FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        public Boolean FileExist
        {
            get
            {
                return (_fileName != null) && (_fileName.Length > 0);
            }
        }


        private DateTime _created;
        public DateTime Created
        {
            get { return _created; }
            set { _created = value; }
        }

        private Company _company;
        public Company Company
        {
            get { return _company; }
            set { _company = value; }
        }
        
        private Person _ourReference;

        public Person OurReference
        {
            get { return _ourReference; }
            set { _ourReference = value; }
        }
        private Person _theirReference;

        public Person TheirReference
        {
            get { return _theirReference; }
            set { _theirReference = value; }
        }

        public Boolean Finished
        {
            get
            {
                return ((Status == QuoteStatus.Accepted) || (Status == QuoteStatus.Rejected));
            }
        }

        public Boolean Locked
        {
            get
            {
                return (Status != QuoteStatus.New);
            }
        }

        private QuoteStatus _quoteStatus;   
        public QuoteStatus Status
        {
            get
            {
                try
                {
                    return _quoteStatus;
                }
                catch
                {
                    return QuoteStatus.Locked;
                }
            }
            set
            {
                //Not allow to go from something else to new again.
                if (value != QuoteStatus.New)
                {
                    _quoteStatus = value;
                }
            }
        }

        public String StatusAsString
        {
            get
            {
                return "";// Yesugi.ResourceManager.GetString(DescriptionValueEnum.GetDescriptionValue(Status));
            }
        }

        /// <summary>
        /// Activity bounded to this quote
        /// </summary>
        public TunityActivity Activity;


        /// <summary>
        /// The rows connected to this quote
        /// </summary>
        public IEnumerable<QuoteRow> Rows
        {
            get
            {
                return Db.SQL<QuoteRow>("SELECT a FROM QuoteRow a WHERE a.Quote=?", this);
            }
        }

        /// <summary>
        /// Remove the versions connected to this document.
        /// </summary>        
        protected override void OnDelete()
        {
            base.OnDelete();
            foreach (QuoteRow row in Rows)
            {
                row.Delete();
            }
        }
    }
}
