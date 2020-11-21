namespace APIPublications.Model.response
{
    public class PublicationResponseModel
    {
        public PublicationResponseModel(int idPost, int idUserPost, string publicationTitle, string publicationContent, string creationDate)
        {
            IdPost = idPost;
            IdUserPost = idUserPost;
            PublicationTitle = publicationTitle;
            PublicationContent = publicationContent;
            CreationDate = creationDate;
        }

        public int IdPost { get; set; }
        public int IdUserPost { get; set; }
        public string PublicationTitle { get; set; }
        public string PublicationContent { get; set; }
        public string CreationDate { get; set; }
    }
}