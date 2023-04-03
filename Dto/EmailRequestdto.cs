namespace MeroBolee.Dto
{
    public class EmailRequestdto
    {
        public string toEmailId {get; set;}

        public string token {get; set;}
        public string id {get; set;}

        public string confirmationLink { get; set; }

        public string role { get; set;}
        
        public string callFrom { get; set; }
        
        public string htmlContent { get; set; }
        
        public string subject { get; set; }

        public string Otp { get; set; }
    }
}