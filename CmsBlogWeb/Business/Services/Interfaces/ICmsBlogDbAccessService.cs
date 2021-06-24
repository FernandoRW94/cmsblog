using System.Collections.Generic;
using System.Threading.Tasks;

namespace CmsBlogWeb.Business.Services.Interfaces
{
    public interface ICmsBlogDbAccessService
    {
        Task<int> ExecuteNonQuery(string commandText, Dictionary<string, string> parameters);
    }
}
