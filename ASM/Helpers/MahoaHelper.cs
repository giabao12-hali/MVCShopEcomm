using System.Security.Cryptography;
using System.Text;

namespace ASM.Helpers
{
    public interface IMahoaHelpers
    {
        string Mahoa(string source);
    }
    public class Mahoahelpers : IMahoaHelpers
    {
        public string Mahoa(string source)
        {
            string hash = "";
            using (var md5Hash = MD5.Create())
            {
                var sourceBytes = Encoding.UTF8.GetBytes(source);
                var hashBytess = md5Hash.ComputeHash(sourceBytes);
                hash = BitConverter.ToString(hashBytess).Replace("-", string.Empty);
            }
            return hash;
        }
    }
}
