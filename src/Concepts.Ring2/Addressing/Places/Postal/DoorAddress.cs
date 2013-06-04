using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;
using Starcounter;


namespace Concepts.Ring2
{
    /// <summary>
    /// An address used to visit people or organisations or to send them mail or parcels.
    /// <code>
    /// Somebody Jocke = new Somebody();
    /// HomeAddress homeAddress = new HomeAddress();
    /// Address address = new Address();
    /// address.Door = "14B;
    /// address.House = "Kensington Court Gardens");
    /// address.Street = "Kensington Court Place");
    /// address.PostCode = "W8 5QE";
    /// address.Country = "United Kingdom";
    /// 
    /// // Will assure a structure looking like this.
    /// // Planet
    /// //    Country
    /// //          City
    /// //              PostCode
    /// //                   Street
    /// //                       House
    /// //                            Door
    /// </code>
    /// <code>
    /// Street street = Street.Kind.Instance.Assure("Kensington Court Gardens");
    /// Postcode postcode = Postcode._.Assure("W8 5QE");
    /// City city = City._.Assure("London");
    /// Country country = Country._.Assure("United Kingdom");
    /// Address address = Address._.Assure("14B");
    /// 
    /// Person jocke = new Person();
    /// jocke.AssureAddress( HomeAddress.Kind.Instance, address );
    /// </code>
    /// </summary>
    /// <ontlogy>
    /// <equal>wordnet:X</equal>
    /// <equal>sumo:X</equal>
    /// </ontlogy>
    public class DoorAddress : PostalAddress
    {
        #region Kind class
        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="SpatialAddress.Kind"/>
        public new class Kind : PostalAddress.Kind
        {

        }
        #endregion

        /// <summary>
        /// The most specific component of an address. 
        /// E.g. "14B" as a specific apartment the street given 
        /// by the PartOf property.
        /// </summary>
        [SynonymousTo("Name")]
        public String DoorNo;

        /// <summary>
        /// The name of the person/organisation as visible on 
        /// any sign in association with the door/apartment, if any.
        /// </summary>
        public string CareOf;

        /// <summary>
        /// "Flat" view of address.
        /// </summary>
        public Country Country;
        public City City;
        public Postcode Postcode;
        public Street Street;
        public PostBox Boxaddress;
        public House House;
        public DoorAddress Door;

        /// <summary>
        /// 
        /// </summary>
        public override string MultiLineAddress
        {
            get
            {
                Address next = PartOf;
                String  cityName =      String.Empty, 
                        postCodeName =  String.Empty, 
                        streetName =    String.Empty;

                while (next != null)
                {
                    if (next is City)
                    {
                        cityName = next.Name;
                    }
                    else if (next is Postcode)
                    {
                        postCodeName = next.Name;
                    }
                    else if (next is Street)
                    {
                        streetName = next.Name;
                    }
                    next = next.PartOf;
                }
                return streetName + " " + DoorNo + "\r\n" + postCodeName + " " + cityName;
            }
            set
            {
                base.MultiLineAddress = value;
            }
        }
    }
}