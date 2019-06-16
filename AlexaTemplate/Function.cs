using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using AlexaTemplate.Handlers.BaseHandlers;
using AlexaTemplate.Handlers.IntentHandlers;
using AlexaTemplate.Helpers;
using AlexaTemplate.Interface;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AlexaTemplate
{
    public class Function
    {

        public static List<IRequestHandler> IntentHandlers = new List<IRequestHandler>();
        public static IRequestHandler LaunchHandler;
        public static IRequestHandler AccountLinkHandler;
        public static IRequestHandler SessionEndHandler;

        //The base functions have already been implimented as an example on how to create and add new
        //intent handlers. 
        public void AddIntentListeners()
        {
            IntentHandlers.Add(new FallbackIntent());
            IntentHandlers.Add(new CancelIntent());
            IntentHandlers.Add(new HelpIntent());
            IntentHandlers.Add(new StopIntent());
            IntentHandlers.Add(new NavigateHomeIntent());
        }

        //The base functions have already been implimented and will be called when the session is started,
        //or the user wished to return to the home state of your skill
        public void SetLaunchRequestHandler()
        {
            LaunchHandler = new LaunchHandler();
        }

        //This base function has been left empty and your skill will provide the user with a generic
        //error message. The account linking is not a required response to handle.
        public void SetAccountLinkHandler()
        {
            AccountLinkHandler = null;
        }

        //This base function has been implimented and will be called when the session ends.
        public void SetSessionEndHandler()
        {
            SessionEndHandler = null;
        }

        //This is the base function of the alexa skill. It will direct the input to the correct handler
        //as configured above.
        public SkillResponse FunctionHandler(SkillRequest input, ILambdaContext context)
        {
            AddIntentListeners();
            SetLaunchRequestHandler();
            SetAccountLinkHandler();
            SetSessionEndHandler();

            if (input.GetRequestType() == typeof(IntentRequest))
            {
                var _Request = input.Request as IntentRequest;

                foreach (IRequestHandler handler in IntentHandlers)
                {
                    if (handler.Name.ToLower() == _Request.Intent.Name.ToLower())
                    {
                        return handler.Run(_Request);
                    }
                }

                return new FallbackIntent().Run(null);
            }
            else if (input.GetRequestType() == typeof(LaunchRequest))
            {
                var _Request = input.Request as LaunchRequest;
                if (LaunchHandler != null)
                {
                    return LaunchHandler.Run(_Request);
                }

                return new FallbackIntent().Run(null);
            }
            else if (input.GetRequestType() == typeof(AccountLinkSkillEventRequest))
            {
                var _Request = input.Request as AccountLinkSkillEventRequest;
                if (AccountLinkHandler != null)
                {
                    return AccountLinkHandler.Run(_Request);
                }

                return new FallbackIntent().Run(null);
            }
            else if (input.GetRequestType() == typeof(SessionEndedRequest))
            {
                var _Request = input.Request as SessionEndedRequest;
                if (SessionEndHandler != null)
                {
                    return SessionEndHandler.Run(_Request);
                }

                return new FallbackIntent().Run(null);
            }

            return new FallbackIntent().Run(null);
        }

    }
}
