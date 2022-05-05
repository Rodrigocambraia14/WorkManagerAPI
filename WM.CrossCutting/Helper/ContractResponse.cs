using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WM.CrossCutting.Helper
{
    public class ContractResponse
    {
        public bool Valid { get; set; }

        public string? Message { get; set; }

        public object? Data { get; set; }

        public ContractResponse()
        {
        }

        public ContractResponse(bool valid, string message, object? data = null)
        {
            Valid = valid;
            Message = message;
            Data = data;
        }

        public static ContractResponse InvalidContractResult(string message)
        {
            return new ContractResponse(valid: false, message);
        }

        public static ContractResponse InvalidContractResult(string message, object data)
        {
            return new ContractResponse(valid: false, message, data);
        }

        public static ContractResponse ValidContractResult(string message, object data)
        {
            return new ContractResponse(valid: true, message, data);
        }

        public static ContractResponse ValidContractResult(string message)
        {
            return new ContractResponse(valid: true, message);
        }
    }
}
