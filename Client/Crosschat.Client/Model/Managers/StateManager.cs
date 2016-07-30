using System;
using System.Linq;

namespace Crosschat.Client
{
	public class StateManager
	{
		static readonly StateManager _instance = new StateManager();

		public static StateManager Instance
		{
			get
			{
				return _instance;
			}
		}

		private StateManager()
		{
		}

		public Interaction GetNextInteraction(int id = 0)
		{
			return ConversationFactory.Get().Where(x => x.Id == id).First();
		}
	}
}

