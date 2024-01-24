namespace PC_Web_Shop.Endpoints.PopustEndpoints.PopustGetById
{
    public class PopustGetByIdResponse
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public DateTime DatumDo { get; set; }
        public DateTime DatumOd { get; set; }
        public float Procenat { get; set; }
        public bool IsDeleted { get; set; }
    }
}
