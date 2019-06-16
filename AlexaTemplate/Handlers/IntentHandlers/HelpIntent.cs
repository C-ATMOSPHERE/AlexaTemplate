using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Amazon.Lambda.Core;
using AlexaTemplate.Helpers;
using AlexaTemplate.Interface;


namespace AlexaTemplate.Handlers.IntentHandlers
{
    class HelpIntent : IRequestHandler
    {
        public string Name => "AMAZON.HelpIntent";

        public SkillResponse Run(Request pRequest)
        {
            //We pass false in to the helper function to keep the session alive with the user and
            //allow them to respond.
            return ResponseHelper.CreateTextResponse("This is a help message", false);
        }
    }
}
