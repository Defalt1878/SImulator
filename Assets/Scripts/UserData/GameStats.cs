using System;

namespace UserData
{
	[Serializable]
	public class GameStats
	{
		private int _money;

		public int Money
		{
			get => _money;
			set
			{
				if (value < 0)
					throw new ArgumentException();
				_money = value;
				OnValueChanged?.Invoke(nameof(Money), MoneyStr);
			}
		}

		public string MoneyStr => $"{Money} $";

		[field: NonSerialized] public event Action<string, string> OnValueChanged;
	}
}