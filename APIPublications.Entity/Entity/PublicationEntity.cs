using System;

namespace APIPublications.Entity.Entity
{
    public class PublicationEntity
    {
        public PublicationEntity()
        {
        }
        public PublicationEntity(int idPost, int idUserPost, string publicationTitle, string publicationContent, DateTime creationDate)
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
        public DateTime CreationDate { get; set; }
    }
}