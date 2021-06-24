using CmsBlogWeb.Business.Services.Interfaces;
using Newtonsoft.Json;
using OrchardCore;
using OrchardCore.ContentManagement;
using System.Threading.Tasks;

namespace CmsBlogWeb.Business.Services
{
    public class OrchardCoreContentService : IOrchardCoreContentService
    {
        private readonly IOrchardHelper _orchardHelper;

        public OrchardCoreContentService(IOrchardHelper orchardHelper)
        {
            _orchardHelper = orchardHelper;
        }

        public async Task<T> GetTypedObject<T>(string alias)
        {
            var content = await this._orchardHelper.GetContentItemByAliasAsync(alias);

            if (content == null)
            {
                return default;
            }

            var serializedObj = JsonConvert.SerializeObject(content, Formatting.Indented);
            return JsonConvert.DeserializeObject<T>(serializedObj);
        }

        public T GetTypedObject<T>(ContentItem content)
        {
            if(content == null)
            {
                return default;
            }

            var serializedObj = JsonConvert.SerializeObject(content, Formatting.Indented);
            return JsonConvert.DeserializeObject<T>(serializedObj);
        }
    }
}
