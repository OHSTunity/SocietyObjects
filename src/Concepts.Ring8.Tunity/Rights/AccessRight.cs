using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring3.SystemX;


namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// The different possible right settings
    /// </summary>
    public enum AccessRight
    {
        [DescriptionValue("Right to change configuration of the server. (Users/groups etc)")]
        [DefaultValue("false")]
        CONFIGURATION,

        [DescriptionValue("Right to see activities that user is not part of")]
        [DefaultValue("false")]
        NON_MEMBER_ACTIVITIES,

        [DescriptionValue("Right to upload documents")]
        [DefaultValue("false")]
        UPLOAD_DOCUMENTS,

        [DescriptionValue("Right to change/delete documents/version/formats")]
        [DefaultValue("false")]
        CHANGE_DOCUMENTS,

        [DescriptionValue("Right to download documents")]
        [DefaultValue("false")]
        DOCUMENTS,

        [DescriptionValue("Right to move and change dates on activities (gantt)")]
        [DefaultValue("false")]
        SCHEMA_CHANGE,


        [DescriptionValue("Right to change details in an activity")]
        [DefaultValue("false")]
        ACTIVITY_CHANGE,


        [DescriptionValue("Right to use fast links from organizer to warehouse")]
        [DefaultValue("false")]
        LINK_WAREHOUSE,


        [DescriptionValue("Right to create reports (organizer)")]
        [DefaultValue("false")]
        REPORTS,


        //******************************************
        // Portfolio
        //******************************************
        [DescriptionValue("Right to report time")]
        [DefaultValue("false")]
        TIME_REPORT,

        [DescriptionValue("Right to report time for someone else")]
        [DefaultValue("false")]
        TIME_REPORT_OTHER,

        [DescriptionValue("Right to plan time")]
        [DefaultValue("false")]
        TIME_PLANNING,

        [DescriptionValue("Right to create and edit quotes")]
        [DefaultValue("false")]
        QUOTES_EDIT,

        [DescriptionValue("Right to view quotes")]
        [DefaultValue("false")]
        QUOTES_VIEW,

        //******************************************
        // Portfolio
        //******************************************
        [DescriptionValue("Right to remove comments")]
        [DefaultValue("false")]
        REMOVE_COMMENTS,

    }

}

