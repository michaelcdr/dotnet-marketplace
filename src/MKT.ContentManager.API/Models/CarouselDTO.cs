namespace MKT.ContentManager.API.Models
{
    public class CarouselDTO
    {
        public string File { get; set; }  = string.Empty;
        public CarouselDTO()
        {
            
        }
        public CarouselDTO(string file)
        {
            File = file;
        }
    }
}
