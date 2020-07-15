using Alexa.NET;
using Alexa.NET.Reminders;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using DemoPrayerSkill.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPrayerSkill.Contract
{
    public class AmazonYesIntentHandler : IAmazonYesIntentHandler
    {
        public async Task<SkillResponse> HandleIntent(IntentRequest input, Session session, SkillRequest request)
        {
            var user = request.Context.System.User;
            if (user.Permissions == null)
            {
                String reminderText = "Please go to the Alexa mobile app to grant reminders permissions.";
                Reprompt r = new Reprompt(reminderText);
                return ResponseBuilder.TellWithAskForPermissionConsentCard(reminderText, new string[]{"alexa::alerts:reminders:skill:readwrite"}, session);   
            }
            try
            {
                var reminder = new Reminder
                {
                    RequestTime = DateTime.UtcNow,
                    Trigger = new RelativeTrigger(12 * 60 * 60),
                    AlertInformation = new AlertInformation(new[] { new SpokenContent("it's a test", "en-GB") }),
                    PushNotification = PushNotification.Enabled
                };
                var client = new RemindersClient(RemindersClient.ReminderDomain, request.Context.System.ApiAccessToken);
                // var alertList = await client.Get();
                var alertDetail = await client.Create(reminder);
                String speechText = "You successfully schedule a daily reminder at one p. m. to get an apple";
                Reprompt rp = new Reprompt(speechText);
                var response = ResponseBuilder.Ask(speechText, rp, session);
                return response;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.StackTrace);
                return ResponseBuilder.Ask("Some error occured while creating reminder", null);
            }
        }
    }
}
