/**
 * Role should inherit Attribute
 * WhatIs should be synonomus to Attribute.Value
 * 
 * Rename ReferedQuantity => ReferredQuantity
 * Remove ValidFrom
 * Remove ValidTo
 */



using System;
using Starcounter;
using System.Collections;
using System.Collections.Generic;


namespace Concepts.Ring1
{
    
    public abstract class Role : Attribute
	{

		/// <summary>
		/// The object that has this role. E.g. if this role is a Father, <c>WhatIs</c> would
		/// be the person that is the father, and the (see cref="ToWhat")ToWhat Property(/see)
		/// would be the son or daughter person.
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
		///     stored in the <see cref="WhatIs">WhatIs Property</see> and the
		///     (see cref="ToWhat")ToWhat Property(/see). To make sure that the correct object goes
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
        //private Something _WhatIs;

        /// <summary>
        /// 
        /// </summary>
        [SynonymousTo("Value")]
		public readonly Something WhatIs;

        /// <summary>
        /// Initiate WhatIs property.
        /// </summary>
        /// <param name="whatIs"></param>
        public void SetWhatIs(Something whatIs)
        {
            SetValue(whatIs);
        }

        /// <summary>
        /// Creats a clone object of this.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public override T Clone<T>() 
        {
            Role role = base.Clone<T>() as Role;
            role.SetWhatIs(WhatIs);
            return role as T;
        }

	}
}