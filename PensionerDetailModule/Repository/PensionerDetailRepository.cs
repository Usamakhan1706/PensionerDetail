using CsvHelper;
using PensionerDetailModule.Mappers;
using PensionerDetailModule.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionerDetailModule.Repository
{
    public class PensionerDetailRepository : IPensionerDetailsRepository
    {
        public async Task<List<PensionerDetail>> ReadCSVFile(string location)
        {
            try
            {
                using (var reader = new StreamReader(location, Encoding.Default))
                {

                    using (var csv = new CsvReader(reader))
                    {
                        csv.Configuration.RegisterClassMap<PensionerDetailMap>();
                        var records = csv.GetRecords<PensionerDetail>().ToList();
                        return records;
                    }
                }
            }
            catch (Exception e)
            {
       
                throw new Exception(e.ToString());
            }
        }

        //public void WriteCSVFile(string path, List<PensionerDetail> pensionerDetail)
        //{
        //    using (StreamWriter sw = new StreamWriter(path, false, new UTF8Encoding(true)))
        //    {
        //        using (CsvWriter cw = new CsvWriter(sw))
        //        {
        //            cw.WriteHeader<PensionerDetail>();
        //            cw.NextRecord();
        //            foreach (PensionerDetail stu in pensionerDetail)
        //            {
        //                cw.WriteRecord<PensionerDetail>(stu);
        //                cw.NextRecord();
        //            }
        //        }
        //    }
        //}
    }
}
