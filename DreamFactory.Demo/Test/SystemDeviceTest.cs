namespace DreamFactory.Demo.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.User;
    using DreamFactory.Rest;
    using DeviceResponse = DreamFactory.Model.System.Device.DeviceResponse;

    public class SystemDeviceTest : IRunnable
    {
        public async Task RunAsync(IRestContext context)
        {
            ISystemApi systemApi = context.Factory.CreateSystemApi();
            
            IList<DeviceResponse> devices = (await systemApi.GetDevicesAsync(new SqlQuery())).ToList();
            await DeleteAnyDevices(devices, systemApi);

            IUserApi userApi = context.Factory.CreateUserApi();
            DeviceRequest device = new DeviceRequest
            {
                Uuid = "1",
                Model = "model",
                Platform = "windows",
                Version = "1.0"
            };

            bool ok = await userApi.SetDeviceAsync(device);
            Console.WriteLine("SetDeviceAsync(): success={0}", ok);

            SqlQuery query = new SqlQuery { Filter = "platform=\"windows\"", Fields = "*" };
            devices = (await systemApi.GetDevicesAsync(query)).ToList();
            Console.WriteLine("GetDevicesAsync(): {0}", context.ContentSerializer.Serialize(devices.Single()));

            await DeleteAnyDevices(devices, systemApi);
        }

        private static async Task DeleteAnyDevices(IList<DeviceResponse> devices, ISystemApi systemApi)
        {
            if (devices.Any())
            {
                int[] ids = devices.Select(x => x.Id ?? 0).ToArray();
                await systemApi.DeleteDevicesAsync(ids);
                Console.WriteLine("DeleteDevicesAsync()");
            }
        }
    }
}
