using MailService.Models;
using System;
using System.Threading.Tasks;

namespace MailService
{
    public interface IMailService
    {
        Task SendMailAsync(MailRequest mailRequest);
    }
}
