using PensionerDetailModule.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PensionerDetailModule.Repository
{
    public interface IPensionerDetailsRepository
    {
        Task<List<PensionerDetail>> ReadCSVFile(string location);
        //void WriteCSVFile(string path, List<PensionerDetail> pensionerDetail);
    }
}
