namespace InquiryPlate.Data
{
    public class Plate
    {
        public long Id { get; set; }
        public string LicensePlate { get; set; }
        public virtual ICollection<Infraction> Infractions { get; set; }
    }

    public class Infraction
    {
        public long Id { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string DateTime { get; set; }
    }

}
