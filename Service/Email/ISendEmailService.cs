namespace MeroBolee.Service;

using MeroBolee.Dto;

public interface ISendEmailService
{
    public SendEmailResponseDto SendEmail(EmailRequestdto emailRequestdto);

}