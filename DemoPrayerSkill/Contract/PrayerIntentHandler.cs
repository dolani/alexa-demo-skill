using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using DemoPrayerSkill.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPrayerSkill.Contract
{
    public class PrayerIntentHandler : IPrayerIntentHandler
    {
        public Task<SkillResponse> HandleIntent(IntentRequest input, Session session, SkillRequest request = null)
        {
            throw new NotImplementedException();
        }
    }
}
