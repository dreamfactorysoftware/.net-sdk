namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.File;
    using DreamFactory.Serialization;

    internal partial class FilesApi : BaseApi, IFilesApi
    {
        private const string OctetStream = "application/octet-stream";

        public FilesApi(IHttpAddress baseAddress, IHttpFacade httpFacade, IContentSerializer contentSerializer, HttpHeaders baseHeaders, string serviceName)
            : base(baseAddress, httpFacade, contentSerializer, baseHeaders, serviceName)
        {
        }

        public async Task<IEnumerable<StorageResource>> GetResourcesAsync(ListingFlags flags)
        {
            SqlQuery query = new SqlQuery();
            query.CustomParameters = AddListingParameters(query.CustomParameters, flags);

            ResourceWrapper<StorageResource> response = await base.RequestAsync<ResourceWrapper<StorageResource>>(
                method: HttpMethod.Get,
                resource: string.Empty, 
                query: query
                );

            return response.Records;
        }

        public async Task<IEnumerable<string>> GetResourceNamesAsync()
        {
            var containers = await GetResourcesAsync(ListingFlags.IncludeFiles | ListingFlags.IncludeFolders);
            return containers.Select(x => x.Name);
        }

        private static Dictionary<string, object> AddListingParameters(Dictionary<string, object> parameters, ListingFlags mode)
        {
            Dictionary<string, object> result = new Dictionary<string, object>(parameters);
            int modeInt = (int)mode;

            if ((modeInt & (int)ListingFlags.IncludeFiles) != 0)
            {
                result.Add("include_files", true);
            }

            if ((modeInt & (int)ListingFlags.IncludeFolders) != 0)
            {
                result.Add("include_folders", true);
            }

            if ((modeInt & (int)ListingFlags.IncludeProperties) != 0)
            {
                result.Add("include_properties", true);
            }

            if ((modeInt & (int)ListingFlags.IncludeSubFolders) != 0)
            {
                result.Add("full_tree", true);
            }

            return result;
        }
    }
}
