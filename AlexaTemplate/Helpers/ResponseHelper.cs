using Alexa.NET;
using Alexa.NET.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaTemplate.Helpers
{
    class ResponseHelper
    {
        //This is a basic voice response to the user and set to always close the session by default.
        public static SkillResponse CreateTextResponse(string pText, bool pEndSession = true)
        {
            var _Speech = new PlainTextOutputSpeech();
            _Speech.Text = pText;
            var _Response = ResponseBuilder.Tell(_Speech);
            _Response.Response.ShouldEndSession = pEndSession;
            return _Response;
        }
    }
}
