namespace PC_Web_Shop.Endpoints.GaradoviEndpoints.GetAll
{
    public class GradGetAllResponse
    {
        public List<GradGetAllResponseGradovi> Gradovi {  get; set; }
    }
    public class GradGetAllResponseGradovi
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
    }
}
