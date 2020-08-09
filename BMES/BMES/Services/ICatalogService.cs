using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMES.ViewModels.Catalogue;

namespace BMES.Services
{
    public interface ICatalogService
    {
        PagedProductViewModel FetchProducts(string categorySlug, string brandSlug);

        
    }
}
