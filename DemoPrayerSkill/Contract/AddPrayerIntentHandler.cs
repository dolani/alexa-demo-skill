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
    public class AddPrayerIntentHandler : IAddPrayerIntentHandler
    {
        public Task<SkillResponse> HandleIntent(IntentRequest input, Session session, SkillRequest request = null)
        {
            string itm = input.Intent.Name;
            string msg = string.Empty;
            if (string.IsNullOrEmpty(itm))
            {
                msg = "I did not get that. Would you like to ask again?";
                Reprompt er = new Reprompt(msg);
                var resp = ResponseBuilder.Ask(msg, er, session);
                return Task.FromResult(resp);
            }

            msg = $"What is your prayer request, please?";
            Reprompt rp = new Reprompt(msg);
            var response = ResponseBuilder.Ask(msg, rp, session);

            // grab input and where to save it to : session???
            return Task.FromResult(response);
        }
    }
}
