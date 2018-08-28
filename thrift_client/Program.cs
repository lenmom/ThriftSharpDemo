using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Transport;

namespace thrift_client
{
    class Program
    {
        static void Main(string[] args)
        {
            TTransport transport = new TSocket("127.0.0.1", 7911);
            TProtocol protocol = new TBinaryProtocol(transport);
            ThriftCase.Client client = new ThriftCase.Client(protocol);

            transport.Open();
            try
            {
                int i = client.testCase1(1, 2, "3");
                Console.WriteLine(i);

                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("num1", "1");
                dic.Add("num2", "2");
                List<string> values = client.testCase2(dic);
                foreach (var item in values)
                {
                    Console.WriteLine(item);
                }


            }
            catch (Thrift.TApplicationException x)
            {
                Console.WriteLine(x.StackTrace);

            }
            finally
            {
                transport.Close();
            }

            Console.ReadKey();
        }
    }
}
