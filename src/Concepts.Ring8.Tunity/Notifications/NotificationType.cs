using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring3.SystemX;


namespace Concepts.Ring8.Tunity
{
    /// <summary>
    ///  Different types of notification
    ///  The description values are autotranslated so only put the "link" to the translation here.
    /// </summary>
    public enum NotificationType
    {
        [DescriptionValue("None (removed/not found/unspecified types)")]
        [DefaultNotificationSetting(false,false, false)]
        None = 0,

        [DescriptionValue("Notifications.ActivityStart.Description")]
        [DefaultNotificationSetting(true, true, true)]
        ActivityStart = 1,


        [DescriptionValue("Notifications.ActivityEnd.Description")]
        [DefaultNotificationSetting(true, true, true)]
        ActivityEnd = 2,

        [DescriptionValue("Notifications.ActivityChanged.Description")]
        [DefaultNotificationSetting(true, false, false)]
        ActivityChanged = 3,

        [DescriptionValue("Notifications.VersionComment.Description")]
        [DefaultNotificationSetting(true, false, true)]
        Comment = 4,

        [DescriptionValue("Notifications.DocumentAdded.Description")]
        [DefaultNotificationSetting(true, false, true)]
        DocumentAdded = 5,
        
        [DescriptionValue("Notifications.Message.Description")]
        [DefaultNotificationSetting(true, true, false)]
        Message = 6,
        
        [DescriptionValue("Notifications.SystemMessage.Description")]
        [DefaultNotificationSetting(true, false, false)]
        SystemMessage
    }
}

