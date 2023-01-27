namespace Domain.Common
{
	public abstract record ThermalProperties : IdName
	{
		public float Value { get; set; }
	}
}
