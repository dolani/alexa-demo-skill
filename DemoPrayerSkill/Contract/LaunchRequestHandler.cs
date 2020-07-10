using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Response;
using DemoPrayerSkill.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPrayerSkill.Contract
{
    public class LaunchRequestHandler : ILaunchRequestHandler
    {
        public Task<SkillResponse> Launch(Session session)
        {
            string msg = $"Welcome to the Be Still Demo. How would you like to start your demo?";
            Reprompt rp = new Reprompt(msg);
            var response = ResponseBuilder.Ask(msg, rp, session);
            return Task.FromResult(response);
        }
    }
}
