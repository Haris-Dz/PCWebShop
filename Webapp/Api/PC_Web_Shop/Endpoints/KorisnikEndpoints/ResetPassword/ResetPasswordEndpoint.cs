using FIT_Api_Example.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;



namespace PC_Web_Shop.Endpoints.KorisnikEndpoints.ResetPassword
{
    [Microsoft.AspNetCore.Mvc.Route("Lozinka")]
    public class ResetPasswordEndpoint:MyBaseEndpoint<ResetPasswordRequest,IActionResult>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly EmailService _emailService;

        public ResetPasswordEndpoint(ApplicationDbContext applicationDbContext, EmailService emailService)
        {
            _applicationDbContext = applicationDbContext;
            _emailService = emailService;   
        }
        [HttpPost("reset")]

        public override async Task<IActionResult> Obradi([FromBody] ResetPasswordRequest request, CancellationToken cancellationToken)
        {
            var kupac = _applicationDbContext.Kupac.SingleOrDefaultAsync(x => x.Email == request.Email).Result;
            if (kupac == null)
            {
                return NotFound();
            }
            Email emailModel=new Email();
            emailModel.To=kupac.Email;
            emailModel.Subject = "Nova lozinka";
            string novalozinka=TokenGenerator.Generate(9);
           emailModel.Body="Vasa nova lozinka je: "+ novalozinka;
            kupac.Lozinka=novalozinka.HashirajSHA256();
            _applicationDbContext.SaveChanges();



            await _emailService.SendEmailAsync(emailModel);
            return Ok();
        }
     }
}
