using System;
using System.Collections.Generic;

namespace Crosschat.Client
{
	public class ConversationFactory
	{
		
		public ConversationFactory()
		{
		}

		public static List<Interaction> Get()
		{
			var interactions = new List<Interaction>();

			var two = new Prompt
			{
				Id = 1,
				Message = "How much time do you have to learn?",
				Responses = new List<Response>
						{
							new Response {
								Message = "5 min",
								Next = null
							},
							new Response {
								Message = "10 min",
								Next = null
							}
						}
			};

			var one = new Motivator
			{
				Id = 0,
				Message = "Hi, good to see you!",
				Next = two
			};



			interactions.Add(
				one
			);
			interactions.Add(two);
			//var conversation = new Conversation { Start = one };

			//return conversation;
			return interactions;
		}
	}
}

