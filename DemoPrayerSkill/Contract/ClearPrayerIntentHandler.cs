using Alexa.NET;
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
    public class ClearPrayerIntentHandler : IClearPrayerIntentHandler
    {
        public Task<SkillResponse> HandleIntent(IntentRequest input, Session session, SkillRequest request = null)
        {
            var sessionAttr = session.Attributes["prayer_request"];
            var pry_msg = "";
            if (sessionAttr == null)
            {
                pry_msg = "You have no active prayer point to clear";
            }
            else
            {
                session.Attributes["prayer_request"] = null;
                pry_msg = "prayer requests has been cleared!";
            }
            Reprompt rp = new Reprompt(pry_msg);
            var response = ResponseBuilder.Ask(pry_msg, rp, session);
            return Task.FromResult(response);
        }
    }
}
