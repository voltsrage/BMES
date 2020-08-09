using BMES.ViewModels.CheckOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES.Services
{
    public interface ICheckOutService
    {
        void ProcessCheckout(CheckoutViewModel checkoutViewModel);
    }
}
