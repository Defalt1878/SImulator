using UserData;

namespace Windows.Browser.Pages.Email.Data
{
	public class MinerEmail : EmailData
	{
		public static string Name => "Miner";
		public override string SenderName => "Unknown";
		public override string Subject => "Bitcoins";

		public override void OnLoad()
		{
			var instance = StaticData.GetInstance();
			if (instance.Emails.IsCompleted(Name))
				return;
			CheckComplete = (_, _) =>
			{
				//TODO
				OnComplete();
			};
			instance.Stats.OnValueChanged += CheckComplete;
		}

		public override void OnOpen()
		{
			var instance = StaticData.GetInstance();
			if (instance.Emails.IsRead(Name))
				return;
			instance.Emails.MarkAsRead(Name);
			instance.Apps.AddToDownloads("Miner");
		}
		
		private void OnComplete()
		{
			var instance = StaticData.GetInstance();
			if (instance.Emails.IsCompleted(Name))
				return;
			instance.Emails.Complete(Name);
			instance.Stats.OnValueChanged -= CheckComplete;
			//TODO
		}

		private protected override string EmailFolder => "Miner";
	}
}