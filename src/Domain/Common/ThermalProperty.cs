namespace Domain.Common
{
    public abstract record class ThermalProperty : IdName
    {
        public float Value { get; set; }
    }
}
