namespace ProductOil.Enitiy
{
    public class Categoriy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PathUrl { get; set; }
        public List<OilCompany?> OilCompany { get; set; }
        public List<OilProduct?> OilProducts { get; set; }
        public List<FeedBack?> FeedBack { get; set; }
        public List<OilNews?> OilNews { get; set; }
        public List<Exemples?> Exmples { get; set; }
        public List<Client?> Clients { get; set; }
        public List<NeftekorCertified?> NeftekorCertifieds { get; set; }
        public List<Location?> Locations { get; set; }
        public List<BenefitOil?> BenefitOil { get; set; }


    }
}
