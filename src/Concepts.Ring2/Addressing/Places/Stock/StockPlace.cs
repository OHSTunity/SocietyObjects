using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;
using Starcounter;


namespace Concepts.Ring2
{
    public class StockPlace : Place
    {
        public new class Kind : Place.Kind { }

        [SynonymousTo("Owner")]
        public Somebody HostedBy;


        public string FullDepotPath
        {
            get
            {
                String s = "";
                StockPlace currentDepot = this;
                while (currentDepot != null)
                {
                    s = String.Format("{0}\\{1}", currentDepot.AddressID, s);
                    currentDepot = (StockPlace)currentDepot.PartOf;
                }
                return s;
            }
        }

        public override void SetPartOf(Address partOf)
        {
            Owner = (partOf == null)? null: partOf.Owner;
            base.SetPartOf(partOf);
        }


        public IEnumerable<T> Placements<T>(bool recursive, Placement.Kind placementKind) where T : Placement
        {
            return Roles<T>(placementKind, recursive);
        }
        public IEnumerable<T> Placements<T>(bool recursive) where T : Placement
        {
            return Roles<T>(recursive);
        }



    }
}
