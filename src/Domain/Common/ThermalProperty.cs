namespace Domain.Common
{
    public abstract record ThermalProperty : IdName
    {
        public float Value { get; set; }
    }
}
