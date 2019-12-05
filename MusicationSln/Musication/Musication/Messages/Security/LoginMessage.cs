using Musication.Model.Security;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Musication.Messages.Security
{
    public class LoginMessage : PubSubEvent<UserProfile>
    {
    }
}