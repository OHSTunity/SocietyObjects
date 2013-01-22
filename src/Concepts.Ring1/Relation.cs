// Remove LockObject
// ToWhat should be synonymous to Owner

using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;

namespace Concepts.Ring1
{
    /// <summary>Abstract class for something that is something to something.</summary>
    /// <remarks>
    /// 	<para>Consider the following statement:</para>
    /// 	<para><strong>"10 Downing Street</strong> is the <strong>home address</strong> of
    ///     <strong>Tony Blair"</strong></para>
    /// 	<para>The street plays the role as "home address" to Tony Blair. The above real
    ///     world object should be represented as follows in SocietyObjects:</para>
    /// 	<para><strong>HomeAddress</strong> should is a specialisation of
    ///     <strong>SomebodysRole.</strong> Or more specifically of AddressRole which is a
    ///     specialisation of SomebodysRole. Each role has the one property
    ///     <see cref="WhatIs">WhatIs</see>. The address
    ///     <strong>10 Downing Street</strong> is the object that plays the role as
    ///     <strong>HomeAddress.</strong> This means that it should be referenced by the
    ///     <see cref="WhatIs">WhatIs Property</see>. The object to which the address is the
    ///     home address is <strong>Tony Blair</strong>.</para>
    /// </remarks>
    /// <example>
    ///     The sourcecode to set "10 Downing Street" as the home address of Tony blair.
    ///     <code lang="CS" title="The role of an address">
    /// Somebody tony = new Person();
    /// tony.Name = "Tony Blair";
    ///  
    /// Address downing10 = new Address();
    /// downing10.Text = "10 Downingstreet, London W1 5QE, London, United Kingdom";
    ///  
    /// SomebodysRole role;
    /// role = new HomeAddress();   // The class HomeAddress inherits
    ///                             // the class AddressRole that inherits
    ///                             // the class SomebodysRole.
    /// role.WhatIs = downing10;
    /// role.ToWhat = tony;
    ///     </code>
    /// </example>
    /// <ontology>
    /// <equal>wordnet:04365254</equal>
    /// <equal>sumo:BinaryRelation</equal>
    /// <equal>sumo:RelationalAttribute</equal>
    /// </ontology>
    public abstract class Relation : Role
    {
 
        /// <summary>
        /// The object that the <see cref="Role.WhatIs">WhatIs Property</see> is a role of this
        /// kind to. E.g. if this role is a Father, <c>ToWhat</c> would be the person that is the
        /// father, and the <see cref="Role.WhatIs">WhatIs Property</see> would be the son or daughter
        /// person.
        /// </summary>
        /// <example>
        /// 	<code lang="CS" title="Father and daughter">
        /// Person elvis = new Person();
        /// Person lisaMarie = new Person();
        /// elvis.Name = "Elvis Presley";
        /// lisaMarie.Name = "Lisa Marie Presley";
        ///  
        /// SomebodysRole daughter = new Daughter();
        /// daughter.WhatIs = lisaMarie;
        /// daughter.ToWhat = elvis;
        ///     </code>
        /// </example>
        /// <remarks>
        /// 	<para>A role defines the relationship between two objects. The two objects are
        ///     stored in the <see cref="Role.WhatIs">WhatIs Property</see> and the
        ///     <see cref="ToWhat">ToWhat Property</see>. To make sure that the correct object goes
        ///     into the these properties, use the name of the role and make the following
        ///     sentance:</para>
        /// 	<para>&lt;WhatIs&gt; is the/a &lt;nameOfRole&gt; to/of/in/for/at
        ///     &lt;ToWhat&gt;.</para>
        /// 	<para>For example:</para>
        /// 	<list type="bullet">
        /// 		<item><strong>Stockholm</strong> is the <strong>capital</strong> of
        ///         <strong>Sweden</strong>.</item>
        /// 		<item><strong>Joachim Wester</strong> is a <strong>Parent</strong> to
        ///         <strong>Timothy Wester.</strong></item>
        /// 		<item><strong>Bill Gates</strong> is a <strong>founder</strong> of
        ///         <strong>Microsoft</strong></item>
        /// 	</list>
        /// 	<para>From this follows:</para>
        /// 	<list type="bullet">
        /// 		<item>aCapital.WhatIs = Stockholm; aCapital.ToWhat = Sweden;</item>
        /// 		<item>aSon.WhatIs = Timothy; aSon.ToWhat = Joachim;</item>
        /// 		<item>aFounder.WhatIs = Bill; aFounder.ToWhat = Microsoft;</item>
        /// 	</list>
        /// </remarks>
        /// 
        private Something _toWhat;

        [SynonymousTo("_toWhat")]
        public readonly Something ToWhat;

        public virtual void SetToWhat(Something toWhat)
        {
            _toWhat = toWhat;            
        }

        public override T Clone<T>()
        {
            Relation relation = base.Clone<T>() as Relation;
            relation.SetToWhat(ToWhat);
            return relation as T;
        }

    }
}
