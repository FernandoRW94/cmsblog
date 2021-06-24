using OrchardCore.ContentManagement;
using System.Threading.Tasks;

namespace CmsBlogWeb.Business.Services.Interfaces
{
    public interface IOrchardCoreContentService
    {
        Task<T> GetTypedObject<T>(string alias);

        T GetTypedObject<T>(ContentItem content);
    }
}
