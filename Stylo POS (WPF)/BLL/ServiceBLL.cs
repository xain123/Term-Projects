using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL;
namespace BLL
{
    public class ServiceBLL
    {
        ServiceDAL sd = new ServiceDAL();
        public ItemBO searchItem(ItemBO item)
        {
            return sd.searchIteam(item);
        }

        public int addService(ServiceBO item)
        {
            return sd.newService(item);
        }

        public int updateService(ServiceBO item)
        {
            return sd.UpdateService(item);
        }

        public ServiceForUpdateBO searchToUpdateItem(ServiceForUpdateBO item)
        {
            return sd.searchToUpdateIteam(item);
        }
    }
}
