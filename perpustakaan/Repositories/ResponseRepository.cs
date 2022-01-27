using perpustakaan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perpustakaan.Repositories
{
    public class ResponseRepository
    {
        public ResponseRepository()
        {

        }
        public Response ResponseMessage(string Code, string Status, string Message, object Data)
        {
            Response Hasil = new Response();
            Hasil.Code = Code;
            Hasil.Status = Status;
            Hasil.Message = Message;
            Hasil.Data = Data;
            return Hasil;
        }
    }
}
