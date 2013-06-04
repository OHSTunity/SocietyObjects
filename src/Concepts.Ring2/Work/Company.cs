using System;
using System.Collections;
using System.Collections.Generic;
using Starcounter;
using Concepts.Ring1;


namespace Concepts.Ring2
{
    /// <summary>
    /// 
    /// </summary>
    public class Company : Organisation
    {
       
        /// <summary>
        /// Mother company to this company.
        /// </summary>
        
        public Company MotherCompany
        {
            get
            {
                /* TODO
                Subsidiary sub = this as Subsidiary;
                return (sub == null) ? null : sub.MotherCompany;
                 * */
                return null;
            }
        }

        /// <summary>
        /// All daughter companies of this company.
        /// </summary>
        
        public IEnumerable<Company> DaughterCompanies
        {
            get
            {
                return this.ImplicitlyRelatedObjects<Company, Subsidiary>();
            }
        }

        /// <summary>
        /// Adds companies to att ref list.
        /// </summary>
        /// <param name="company"></param>
        /// <param name="list"></param>
        private void AddChildren(Company company, ref ArrayList list)
        {
            foreach (Company daughterCompany in company.DaughterCompanies)
            {
                list.Add(daughterCompany);
                AddChildren(daughterCompany, ref list);
            }
        }

        /// <summary>
        /// All daughter companies recursive.
        /// </summary>
        
        public Company[] AllSubsidiaries
        {
            get
            {
                ArrayList arr = new ArrayList();
                this.AddChildren(this, ref arr);
                return (Company[])arr.ToArray(typeof(Company));
            }
        }

        /// <summary>
        /// Adds a daughter company to this company.
        /// </summary>
        /// <param name="company"></param>
        public void AddDaughterCompany(Company company)
        {
            Subsidiary subsidiary = new Subsidiary();
            subsidiary.SetMotherCompany(this);
            subsidiary.SetDaughterCompany(company);
        }

        /// <summary>
        /// Removes the Subsidiary role between this company and the specifies 
        /// daughter company.
        /// </summary>
        public void RemoveAsDaughterCompany()
        {
            /* TODO
            using (SqlEnumerator sqlenum = Sql.GetEnumerator("SELECT result FROM " + Subsidiary.Kind.GetInstance<Subsidiary>().FullInstanceClassName + " result WHERE result.ToWhat=variable(" + Company.Kind.GetInstance<Company.Kind>().FullInstanceClassName + ", company)"))
            {
                sqlenum.SetVariable("company", this);
                while (sqlenum.MoveNext())
                {
                    (sqlenum.Current as Subsidiary).Delete();
                } 
            }
             */
        }


        protected override void OnDelete()
        {
            base.OnDelete();
            this.RemoveAsDaughterCompany();
        }

        /// <summary>
        /// Finds the consumer role towards the given somebody,
        /// search is made recursivly through mother companies.
        /// 
        /// Null is a possible return value.
        /// </summary>
        /// <param name="somebody"></param>
        /// <returns></returns>
        public Consumer AsConsumer(Somebody somebody)
        {
            Consumer consumer = this.RelationTo<Consumer>(somebody);

            if (consumer == null)
            {
                Company motherCompany = MotherCompany;

                if (motherCompany != null)
                {
                    consumer = MotherCompany.AsConsumer(somebody);
                }
            }

            return consumer;
        }

        /// <summary>
        /// Finds the supplier role towards the given somebody,
        /// search is made recursivly through mother companies.
        /// 
        /// Null is a possible return value.
        /// </summary>
        /// <param name="somebody"></param>
        /// <returns></returns>
        public Somebody AsSupplier(Somebody somebody)
        {
            // We call the consumer relation below because we are the supplier of that relation.
            Consumer consumer = somebody.RelationTo<Consumer>(this);
            Somebody supplier = null;

            if (consumer != null)
            {
                supplier = consumer.ToWhom;
            }
            else
            {
                Company motherCompany = MotherCompany;

                if (motherCompany != null)
                {
                    supplier = MotherCompany.AsSupplier(somebody);
                }
            }

            return supplier;
        }

        ///// <summary>
        ///// For a company we need to add the mother companies, they have lower priority than the group owners
        ///// gathered in the base implementation.
        ///// </summary>
        
        //public override IEnumerable<Somebody> RelatedSomebodies
        //{
        //    get
        //    {
        //        List<Somebody> relatedSomebodies = new List<Somebody>();

        //        // Fetch the group owners.
        //        relatedSomebodies.AddRange(base.RelatedSomebodies);

        //        // Add mother company recursivly.
        //        Company motherCompany = MotherCompany;

        //        while (motherCompany != null)
        //        {
        //            if (!relatedSomebodies.Contains(motherCompany))
        //            {
        //                relatedSomebodies.Add(motherCompany);
        //            }
        //            motherCompany = motherCompany.MotherCompany;
        //        }

        //        return relatedSomebodies;
        //    }
        //}

    }
}
