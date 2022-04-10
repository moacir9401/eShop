using eshop.Email.Messages;
using eShop.Email.Model.Base;

namespace eshop.Email.Repository
{
    public interface IEmailRepository
    { 
        Task LogEmail(UpdatePaymentResultMessage message);

    }
}
