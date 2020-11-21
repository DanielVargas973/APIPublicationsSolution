namespace APIPublications.Model.request
{
    public class PublicationRequestModel
    {
        public PublicationRequestModel()
        {
        }

        public int IdPost { get; set; }
        public int IdUserPost { get; set; }
        public string PublicationTitle { get; set; }
        public string PublicationContent { get; set; }
        public string CreationDate { get; set; }
    }
}