using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Mre.OTI.Passport.util.documentos.backend
{
    public static class FormFileUtil
    {
        public static async Task<byte[]> GetBytes(IFormFile formFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
