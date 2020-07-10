using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPrayerSkill.Abstract
{
    public interface IIntentHandler
    {
        Task<SkillResponse> HandleIntent(IntentRequest input, Session session);
    }
}
