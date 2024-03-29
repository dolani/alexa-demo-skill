﻿using Alexa.NET;
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
    public class ViewPrayerIntentHandler : IViewPrayerIntentHandler
    {
        public Task<SkillResponse> HandleIntent(IntentRequest input, Session session, SkillRequest request = null)
        {
            var sessionAttr = session.Attributes["prayer_request"];
            string pry_msg = string.Empty;
            if (sessionAttr == null)
            {
                pry_msg = "You have no active prayer point.";
            }
            else
            {
                pry_msg = (string)session.Attributes["prayer_request"];
            }

            Reprompt rp = new Reprompt(pry_msg);
            SkillResponse response = ResponseBuilder.Ask(pry_msg, rp, session);
            return Task.FromResult(response);
        }
    }
}
