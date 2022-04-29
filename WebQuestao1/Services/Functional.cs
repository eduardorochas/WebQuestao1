using WebQuestao1.Data;
using WebQuestao1.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebQuestao1.Services
{
    public class Functional : IFunctional
    {
       
        private readonly ApplicationDbContext _context;
        

        public Functional(
           ApplicationDbContext context)
        {
           
            _context = context;
           
        }

      

        public async Task InitAppData()
        {
            try
            {
                await _context.LinguaEstrangeira.AddAsync(new LinguaEstrangeira { Nome = "Inglês" });
                await _context.SaveChangesAsync();

                await _context.LinguaEstrangeira.AddAsync(new LinguaEstrangeira { Nome = "Espanhol" });
                await _context.SaveChangesAsync();

                await _context.LinguaEstrangeira.AddAsync(new LinguaEstrangeira { Nome = "Francês" });
                await _context.SaveChangesAsync();

                await _context.Cargo.AddAsync(new Cargo { Nome = "Analista de Sistemas" });
                await _context.SaveChangesAsync();

                await _context.Cargo.AddAsync(new Cargo { Nome = "Administrador" });
                await _context.SaveChangesAsync();

                await _context.Cargo.AddAsync(new Cargo { Nome = "Professor" });
                await _context.SaveChangesAsync();

                await _context.Cargo.AddAsync(new Cargo { Nome = "Engenheiro" });
                await _context.SaveChangesAsync();

                await _context.Cargo.AddAsync(new Cargo { Nome = "Médico" });
                await _context.SaveChangesAsync();


            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task SendEmailBySendGridAsync(string apiKey, 
            string fromEmail, 
            string fromFullName, 
            string subject, 
            string message, 
            string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(fromEmail, fromFullName),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email, email));
            await client.SendEmailAsync(msg);

        }

        public async Task SendEmailByGmailAsync(string fromEmail,
            string fromFullName,
            string subject,
            string messageBody,
            string toEmail,
            string toFullName,
            string smtpUser,
            string smtpPassword,
            string smtpHost,
            int smtpPort,
            bool smtpSSL)
        {
            var body = messageBody;
            var message = new MailMessage();
            message.To.Add(new MailAddress(toEmail, toFullName));
            message.From = new MailAddress(fromEmail, fromFullName);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = smtpUser,
                    Password = smtpPassword
                };
                smtp.Credentials = credential;
                smtp.Host = smtpHost;
                smtp.Port = smtpPort;
                smtp.EnableSsl = smtpSSL;
                await smtp.SendMailAsync(message);

            }

        }

        public async Task CreateDefaultSuperAdmin()
        {
            try
            {
                ////await _roles.GenerateRolesFromPagesAsync();

                ////ApplicationUser superAdmin = new ApplicationUser();
                ////superAdmin.Email = _superAdminDefaultOptions.Email;
                ////superAdmin.UserName = superAdmin.Email;
                ////superAdmin.EmailConfirmed = true;

                ////var result = await _userManager.CreateAsync(superAdmin, _superAdminDefaultOptions.Password);

                //if (result.Succeeded)
                //{
                //    ////add to user profile
                //    //UserProfile profile = new UserProfile();
                //    //profile.FirstName = "Super";
                //    //profile.LastName = "Admin";
                //    //profile.Email = superAdmin.Email;
                //    //profile.ApplicationUserId = superAdmin.Id;
                //    //await _context.UserProfile.AddAsync(profile);
                //    //await _context.SaveChangesAsync();

                //    //await _roles.AddToRoles(superAdmin.Id);
                //}
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<string> UploadFile(List<IFormFile> files, IHostingEnvironment env, string uploadFolder)
        {
            var result = "";

            var webRoot = env.WebRootPath;
            var uploads = System.IO.Path.Combine(webRoot, uploadFolder);
            var extension = "";
            var filePath = "";
            var fileName = "";


            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    extension = System.IO.Path.GetExtension(formFile.FileName);
                    fileName = Guid.NewGuid().ToString() + extension;
                    filePath = System.IO.Path.Combine(uploads, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }

                    result = fileName;

                }
            }

            return result;
        }

    }
}
