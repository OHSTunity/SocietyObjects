using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1.SystemX;

namespace Concepts.Ring1
{
    /// <summary>
    /// Everything in SocietyObjects may have a defintion. The definition describes an object
    /// using free form text, links to well known ontologies and encyclopedias such as Wordnet,
    /// Wikipedia and Sumo and formal axioms.
    /// </summary>
    /// TODO: Review joawes
    //public class Definition : Something
    //{
    //    #region Kind
    //    /// <summary>
    //    /// The Kind class is a fundamental concept in Society Objects. 
    //    /// Read more about it in the basic introduction to Society Objects.
    //    /// </summary>
    //    /// <seealso cref="Role.Kind"/>
    //    public new class Kind : Something.Kind
    //    {
    //    }
    //    #endregion

    //    /// <summary>
    //    /// The object that this defintion represents.
    //    /// </summary>
    //    public Something Defines;

    //    /// <summary>
    //    /// The workspace and consequently the ring assigned to the represented concept.
    //    /// </summary>
    //    public SocietyObjectsWorkspace Workspace;

    //    /// <summary>
    //    /// Mapping to Princeton Wordnet sense key for Wordnet version 1.7.
    //    /// </summary>
    //    public int KeyWordNet17;

    //    /// <summary>
    //    /// Mapping to Princeton Wordnet sense key for Wordnet version 2.0.
    //    /// </summary>
    //    public int KeyWordNet20;

    //    /// <summary>
    //    /// Mapping to Princeton Wordnet sense key for Wordnet version 2.1.
    //    /// </summary>
    //    public int KeyWordNet21;

    //    /// <summary>
    //    /// Mapping to Princeton Wordnet sense key for Wordnet version 3.0.
    //    /// </summary>
    //    public int KeyWordNet30;

    //    public string WordNet21Pos;

    //    public int WordNet21CategoryId;

    //    /// <summary>
    //    /// The Wikipedia article containing information about the represented concept.
    //    /// </summary>
    //    /// <remarks>
    //    /// This key corresponds to the Wikipedia article. The article can be found at
    //    /// using the URL http://en.wikipedia.org/wiki/ immediately followed by the key.
    //    /// For example, the key "Dog" would be found at http://en.wikipedia.org/wiki/Dog
    //    /// </remarks>
    //    public string KeyWikipedia;

    //    /// <summary>
    //    /// The name of the concept in the standardilized SUMO ontology.
    //    /// </summary>
    //    /// <remarks>
    //    /// The string is a foreign key to the Suggested Upper Merged Ontology (SUMO) managed by
    //    /// the Standard Upper Ontology Working Group (SUO WG) IEEE P1600.1.
    //    /// </remarks>
    //    public string KeySumo;

    //    /// <summary>
    //    /// An approximate number of lines of code in the associated class file, if any.
    //    /// </summary>
    //    /// <remarks>
    //    /// Used as a way to identify key kinds that define a lot of attributes and functionality. In a graph
    //    /// showing concepts and their relationship, this property can be used to highlight important kinds and classes.
    //    /// For instance, the size of the nodes displayed in a visual graph could be set according to the amount of code
    //    /// used to define it.
    //    /// </remarks>
    //    public int LinesOfClassSourceCode;

    //    /// <summary>
    //    /// All objects are defined by <c>Somebody</c>. This means that all objects,
    //    /// including every class (or Kind), knows who owns its definition. As SocietyObjects
    //    /// mimics the our perception of the real world, and as our perception of the real world
    //    /// concepts is formed throughout history by all of us and all of our ancestors, the most
    //    /// common definer is the <see cref="Somebody.GeneralSociety">GeneralSociety Somebody
    //    /// Concepts.Ring1.Somebody)</see>.
    //    /// </summary>
    //    public Somebody DefinedBy;

    //    /// <remarks>
    //    /// 	<para>The property ProvidedBy is important as there might be conflicting version in
    //    ///     SocietyObject that correspons to a real world object. A typical example of this is
    //    ///     the Person object. A person is typically defined by an authority in a specific
    //    ///     country, where the name of the person is registred (althogh a person can be defined
    //    ///     by anybody, the goverment defined person is the more rigid defintion). It is
    //    ///     seldomly that the definition (the data) of the person is provided by that authority
    //    ///     though (thank god for that, big brother). In the case of a Person, the
    //    ///     <see cref="ProvidedBy">ProvidedBy Property</see> and the
    //    ///     <see cref="DefinedBy">DefinedBy Property</see> normally points to different
    //    ///     Somebodies. Provider is normally a system owner and defined by is a
    //    ///     government.</para>
    //    /// </remarks>
    //    /// <summary>
    //    /// Identifies any single provider of the data and methods of this object. This is
    //    /// usefull when combined with the possiblity of the Innowait Database System to handle
    //    /// different versions of the same object using the same ObjectNo.
    //    /// </summary>
    //    public Somebody ProvidedBy;
    //}
}
